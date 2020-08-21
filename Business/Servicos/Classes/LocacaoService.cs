using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;
using Netfilmes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Servicos.Classes
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoDAO _locacaoDAO;
        private readonly IFilmeDAO _filmeDAO;

        // Esse construtor recebe as dependencias da classe (ponto de injeção)
        public LocacaoService(ILocacaoDAO locacaoDAO, IFilmeDAO filmeDAO)
        {
            _locacaoDAO = locacaoDAO;
            _filmeDAO = filmeDAO;
        }

        // Cadastra uma nova locação e faz a ligação dos filmes com a mesma
        public bool Cadastrar(Locacao locacao, List<int> filmesId)
        {
            bool sucesso = false;

            try
            {
                // Cadastra a locação
                var locacaoId = _locacaoDAO.Cadastrar(locacao);

                // Verifica se o cadastro foi realizado, analisando o Id gerado
                if (locacaoId > 0)
                {
                    // Percorre a lista de Ids dos filmes selecionados pelo usuario
                    foreach (var id in filmesId)
                    {
                        // Obtem cada filme da locação usando o seu Id
                        var filmeCadastrado = _filmeDAO.ConsultarPorId(id);

                        // Faz a ligação da locação cadastrada com o filme ligado a ela
                        filmeCadastrado.LocacaoId = locacaoId;

                        // Atualiza o filme cadastro, fazendo a ligação com a locação no banco
                        sucesso = _filmeDAO.Cadastrar(filmeCadastrado);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return sucesso;
        }

        // Lista todas as locações
        public List<Locacao> ListarTodos()
        {
            try
            {
                return _locacaoDAO.ListarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Termina o relacionamento dos filmes selecionados com a locacao
        public bool Desalocar(List<int> filmesId)
        {
            bool sucesso = false;

            try
            {
                // Percorre a lista de Ids dos filmes selecionados pelo usuario
                foreach (var id in filmesId)
                {
                    // Obtem cada filme da locação usando o seu Id
                    var filmeLocado = _filmeDAO.ConsultarPorId(id);

                    // Termina o relacionamento do filme com locacao
                    filmeLocado.LocacaoId = null;

                    // Atualiza o filme no banco de dados
                    sucesso = _filmeDAO.Cadastrar(filmeLocado);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return sucesso;
        }
    }
}
