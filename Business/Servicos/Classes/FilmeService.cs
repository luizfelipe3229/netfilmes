using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;
using Netfilmes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Servicos.Classes
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeDAO _filmeDAO;

        // Esse construtor recebe as dependencias da classe (ponto de injeção)
        public FilmeService(IFilmeDAO filmeDAO)
        {
            _filmeDAO = filmeDAO;
        }

        // Recebe um objeto do tipo Filme e o inseri no banco ou 
        // atualiza um registro dele já existente
        public bool Cadastrar(Filme filme)
        {
            try
            {
                return _filmeDAO.Cadastrar(filme);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Lista todos os filmes cadastrados no banco de dados
        public List<Filme> ListarTodos()
        {
            try
            {
                return _filmeDAO.ListarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Deleta os filmes que estão na lista passada
        public bool RemoverSelecionados(List<int> filmesId)
        {
            try
            {
                // Cria uma lista para armazenar os filmes selecionados pelo usuario
                var filmes = new List<Filme>();

                // Percorre a lista de Ids dos filmes selecionados
                foreach (var id in filmesId)
                {
                    // Para cada Id, cria um objeto do tipo Filme e o adiciona na lista de filmes
                    filmes.Add(new Filme() { Id = id });
                }

                // Passa a lista de filmes para que sejam removidos do banco de dados
                return _filmeDAO.RemoverSelecionados(filmes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Obtem um filme pelo seu Id
        public Filme ConsultarPorId(int id)
        {
            try
            {
                return _filmeDAO.ConsultarPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Remove um filme pelo seu Id
        public bool RemoverPorId(int id)
        {
            try
            {
                return _filmeDAO.RemoverPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Lista todos os filmes ativos e não locados
        public List<Filme> ListarNaoLocados()
        {
            try
            {
                return _filmeDAO.ListarNaoLocados();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
