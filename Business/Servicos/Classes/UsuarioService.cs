using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;
using Netfilmes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Servicos.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDAO _usuarioDAO;

        // Esse construtor recebe as dependencias da classe (ponto de injeção)
        public UsuarioService(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        // Recebe um objeto do tipo Usuario e o inseri no banco ou atualiza um registro dele já existente
        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                return _usuarioDAO.Cadastrar(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Busca um usuário com as credenciais informadas
        public Usuario Buscar(Usuario usuario)
        {
            try
            {
                return _usuarioDAO.Buscar(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
