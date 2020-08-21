using Netfilmes.Business.Entidades;

namespace Netfilmes.Repository.Interfaces
{
    public interface IUsuarioDAO
    {
        bool Cadastrar(Usuario usuario);
        Usuario Buscar(Usuario usuario);
    }
}
