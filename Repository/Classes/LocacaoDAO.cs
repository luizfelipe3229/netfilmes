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
    public class LocacaoDAO : ILocacaoDAO
    {
        private String _connectionString;
        private SqlConnection _databaseConnection;

        public LocacaoDAO (IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings"];
        }

        // Cadastra uma nova locação
        public int Cadastrar(Locacao locacao)
        {
            int locacaoId = 0;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO Locacao                  ");
            sql.Append(" (                                    ");
            sql.Append("   Cpf                                ");
            sql.Append(" )                                    ");
            sql.Append(" VALUES                               ");
            sql.Append(" (                                    ");
            sql.Append("   @CPF                               ");
            sql.Append(" )                                    ");
            sql.Append(" SELECT CAST(SCOPE_IDENTITY() AS INT) ");

            try
            {
                // Define os parametros do codigo SQL
                var parametros = new
                {
                    @CPF = locacao.Cpf
                };

                // Obtem uma conexão com o banco de dados
                using (_databaseConnection = new SqlConnection(_connectionString))
                {
                    // Abre a conexão
                    _databaseConnection.Open();

                    // Executa o código SQL e retorna o Id gerado na inserção
                    locacaoId = _databaseConnection.Query<int>(sql.ToString(), parametros).First();
                }

                return locacaoId;
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

        // Retorna todas as locações cadastradas no banco de dados
        public List<Locacao> ListarTodos()
        {
            List<Locacao> locacoes = null;

            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Seleciona todas as locações cadastradas e os seus filmes
                    locacoes = applicationContext.Locacao.Select(locacao => new Locacao()
                    {
                        Id = locacao.Id,
                        Cpf = locacao.Cpf,
                        DataDaLocacao = locacao.DataDaLocacao,
                        Filmes = locacao.Filmes

                    }).ToList();
                }

                return locacoes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
