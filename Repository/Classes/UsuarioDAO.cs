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
    public class UsuarioDAO : IUsuarioDAO
    {
        private String _connectionString;
        private SqlConnection _databaseConnection;

        public UsuarioDAO (IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings"];
        }

        // Realiza a inserção/alteração de um usuário no banco de dados
        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                // Cria uma instancia de ApplicationContext
                using (var applicationContext = new ApplicationContext())
                {
                    // Se a entidade possuir um Id, então a operação de atualização será executada,
                    // caso contrário, a operação de inserção será executada
                    if (usuario.Id > 0)
                    {
                        // Altera um objeto do tipo Usuario no banco de dados
                        applicationContext.Usuario.Update(usuario);
                    }
                    else
                    {
                        // Adiciona o objeto do tipo Usuario a ser gravado no banco de dados
                        applicationContext.Usuario.Add(usuario);
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

        // Busca um usuário pelo seu nome e senha
        public Usuario Buscar(Usuario usuario)
        {
            Usuario usuarioCadastrado = null;

            // Define o código SQL a ser executado
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * FROM Usuario ");
            sql.Append(" WHERE Nome  = @Nome   ");
            sql.Append(" AND   Senha = @Senha  ");

            try
            {
                // Define os parâmetros usados no código SQL
                var parametros = new
                {
                    @Nome = usuario.Nome,
                    @Senha = usuario.Senha
                };

                // Obtem uma conexão com o banco de dados
                using (_databaseConnection = new SqlConnection(_connectionString))
                {
                    // Abre a conexão
                    _databaseConnection.Open();

                    // Executa o código SQL e armazena o resultado na variavel usuario
                    usuarioCadastrado = _databaseConnection.Query<Usuario>(sql.ToString(), parametros).FirstOrDefault();
                }

                return usuarioCadastrado;
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
