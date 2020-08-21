using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;
using Netfilmes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Servicos.Classes
{
    // Classe de servico, aqui são colocadas as lógicas e regras de negócio da aplicação
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroDAO _generoDAO;

        // Esse construtor recebe as dependencias da classe (ponto de injeção)
        public GeneroService(IGeneroDAO generoDAO)
        {
            _generoDAO = generoDAO;
        }

        // Recebe um objeto do tipo Genero e o inseri no banco ou atualiza um registro dele já existente
        public bool Cadastrar(Genero genero)
        {
            try
            {
                return _generoDAO.Cadastrar(genero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Lista todos os generos cadastrados no banco de dados
        public List<Genero> ListarTodos()
        {
            try
            {
                return _generoDAO.ListarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Remove os generos selecionados pelo usuario
        public bool RemoverSelecionados(List<int> generosId)
        {
            try
            {
                // Cria uma lista para armazenar os generos selecionados pelo usuario
                var generos = new List<Genero>();

                // Percorre a lista de Ids dos generos selecionados
                foreach (var id in generosId)
                {
                    // Para cada Id, cria um objeto do tipo Genero e o adiciona na lista de generos
                    generos.Add(new Genero() { Id = id });
                }

                // A lista de generos é passada para a remoção no banco de dados
                return _generoDAO.RemoverSelecionados(generos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Obtem um registro de genero pelo seu Id
        public Genero ConsultarPorId(int id)
        {
            try
            {
                return _generoDAO.ConsultarPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Remove um registro de genero pelo seu Id
        public bool RemoverPorId(int id)
        {
            try
            {
                return _generoDAO.RemoverPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Lista todos os generos ativos
        public List<Genero> ListarAtivos()
        {
            try
            {
                return _generoDAO.ListarAtivos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
