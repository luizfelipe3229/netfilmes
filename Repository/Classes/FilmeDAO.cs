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
using System.Threading.Tasks;

namespace Netfilmes.Repository.Classes
{
    public class FilmeDAO : IFilmeDAO
    {
        private String _connectionString;
        private SqlConnection _databaseConnection;

        public FilmeDAO(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings"];
        }

        // Recebe um objeto do tipo Filme e o insere ou atualiza um registro dele já existente no banco
        public bool Cadastrar(Filme filme)
        {
            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Se a entidade possuir um Id, então a operação de atualização será executada,
                    // caso contrário, a operação de inserção será executada
                    if (filme.Id > 0)
                    {
                        // Altera um objeto do tipo filme no banco de dados
                        applicationContext.Filme.Update(filme);
                    }
                    else
                    {
                        // Adiciona o objeto do tipo Filme a ser gravado no banco de dados
                        applicationContext.Filme.Add(filme);
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

        // Lista todos os filmes cadastrados no banco de dados
        public List<Filme> ListarTodos()
        {
            List<Filme> filmes = null;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT                                    ");
            sql.Append("      F.*                                  ");
            sql.Append("    , G.*                                  ");
            sql.Append("    , L.*                                  ");
            sql.Append(" FROM Filme F                              ");
            sql.Append(" LEFT JOIN Genero G ON F.GeneroId = G.Id   ");
            sql.Append(" LEFT JOIN Locacao L ON F.LocacaoId = L.Id ");
            sql.Append(" ORDER BY F.Id DESC                        ");

            try
            {
                // Obtem uma conexão com o banco de dados
                using (_databaseConnection = new SqlConnection(_connectionString))
                {
                    // Abre a conexão
                    _databaseConnection.Open();

                    // Executa o código SQL e armazena o resultado na variavel filmes
                    filmes = _databaseConnection.Query<Filme, Genero, Locacao, Filme>(sql.ToString(),
                                                                                     (f, g, l) =>
                                                                                     {
                                                                                         f.Genero = g;
                                                                                         f.Locacao = l;
                                                                                     
                                                                                         return f;
                                                                                     },
                                                                                     splitOn: "Id,Id,Id").ToList();
                }

                return filmes;
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

        // Remove do banco de dados os filmes selecionados 
        public bool RemoverSelecionados(List<Filme> filmes)
        {
            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Remove do banco de dados os filmes que estão na lista
                    applicationContext.RemoveRange(filmes);
                    return applicationContext.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Obtem um filme pelo seu Id
        public Filme ConsultarPorId(int id)
        {
            Filme filme = null;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * FROM Filme ");
            sql.Append(" WHERE Id = @Id      ");

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

                    // Executa o código SQL e armazena o resultado na variavel filme
                    filme = _databaseConnection.Query<Filme>(sql.ToString(), parametros).FirstOrDefault();
                }

                return filme;
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

        // Remove um filme pelo seu Id
        public bool RemoverPorId(int id)
        {
            bool sucesso = false;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM Filme ");
            sql.Append(" WHERE Id = @Id    ");

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

        // Lista todos os filmes ativos e não locados
        public List<Filme> ListarNaoLocados()
        {
            List<Filme> filmes = null;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT                                   ");
            sql.Append("      F.*                                 ");
            sql.Append("    , G.*                                 ");
            sql.Append(" FROM Filme F                             ");
            sql.Append(" INNER JOIN Genero G ON F.GeneroId = G.Id ");
            sql.Append(" WHERE F.LocacaoID IS NULL                ");
            sql.Append(" AND F.Ativo = 1                          ");
            sql.Append(" ORDER BY f.Id DESC                       ");

            try
            {
                // Obtem uma conexão com o banco de dados
                using (_databaseConnection = new SqlConnection(_connectionString))
                {
                    // Abre a conexão
                    _databaseConnection.Open();

                    // Executa o código SQL e armazena o resultado na variavel filmes
                    filmes = _databaseConnection.Query<Filme, Genero, Filme>(
                        sql.ToString(),
                        (f, g) =>
                        {
                            f.Genero = g;
                            return f;
                        },
                        splitOn: "Id,Id").ToList();
                }

                return filmes;
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
