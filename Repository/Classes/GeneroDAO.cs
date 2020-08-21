using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Netfilmes.Business.Entidades;
using Netfilmes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Netfilmes.Repository.Classes
{
    public class GeneroDAO : IGeneroDAO
    {
        private String _connectionString;
        private SqlConnection _databaseConnection;

        public GeneroDAO (IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings"];
        }

        // Recebe um objeto do tipo Genero e o insere ou atualiza um registro dele já existente no banco
        public bool Cadastrar(Genero genero)
        {
            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    if (genero.Id > 0)
                    {
                        // Altera um objeto do tipo Genero no banco de dados
                        applicationContext.Genero.Update(genero);
                    }
                    else
                    {
                        // Adiciona o objeto do tipo Genero a ser gravado no banco de dados
                        applicationContext.Genero.Add(genero);
                    }

                    // Realiza a operação de inserção ou alteração, dependendo do estado do objeto
                    return applicationContext.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Lista todos os generos cadastrados no banco de dados
        public List<Genero> ListarTodos()
        {
            List<Genero> generos = null;

            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Seleciona todos os generos e seus filmes relacionados
                    generos = applicationContext.Genero.Select(genero => new Genero()
                    {

                        Id = genero.Id,
                        Nome = genero.Nome,
                        Ativo = genero.Ativo,
                        DataDeCriacao = genero.DataDeCriacao,
                        Filmes = genero.Filmes

                    }).ToList();
                }

                return generos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Lista todos os generos ativos
        public List<Genero> ListarAtivos()
        {
            List<Genero> generosAtivos = null;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * FROM Genero ");
            sql.Append(" WHERE Ativo = 1      ");
            sql.Append(" ORDER BY Nome        ");

            try
            {
                // Obtem uma conexão com o banco de dados
                using (_databaseConnection = new SqlConnection(_connectionString))
                {
                    // Abre a conexão
                    _databaseConnection.Open();

                    // Executa o código SQL
                    generosAtivos = _databaseConnection.Query<Genero>(sql.ToString()).ToList();
                    
                }

                return generosAtivos;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // Verifica se a conexão com o banco está aberta
                if (_databaseConnection.State != ConnectionState.Closed)
                {
                    // Fecha a conexão com o banco apos a operação
                    _databaseConnection.Close();
                }

                // Destroi a instancia de conexão utilizada
                _databaseConnection = null;
            }
        }

        // Remove do banco os generos recebidos
        public bool RemoverSelecionados(List<Genero> generos)
        {
            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Remove do banco de dados os generos que estão na lista
                    applicationContext.RemoveRange(generos);
                    
                    return applicationContext.SaveChanges() > 0;
                }
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
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Obtem o registro de genero que possua o Id passado
                    return applicationContext.Genero.Where(g => g.Id == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Remove um registro de genero pelo seu Id
        public bool RemoverPorId(int id)
        {
            bool sucesso = false;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM Genero ");
            sql.Append(" WHERE Id = @Id     ");

            try
            {
                // Define os parâmetros usados no código SQL
                var parametros = new
                {
                    @Id = id
                };

                // Obtem uma conexão com o banco de dados
                using (_databaseConnection = new SqlConnection(_connectionString))
                {
                    // Abre a conexão
                    _databaseConnection.Open();

                    // Executa o código SQL
                    sucesso = _databaseConnection.Execute(sql.ToString(), parametros) > 0;
                }

                return sucesso;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // Verifica se a conexão com o banco está aberta
                if (_databaseConnection.State != ConnectionState.Closed)
                {
                    // Fecha a conexão com o banco apos a operação
                    _databaseConnection.Close();
                }

                // Destroi a instancia de conexão utilizada
                _databaseConnection = null;
            }
        }
    }
}
