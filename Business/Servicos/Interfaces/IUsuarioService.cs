using Netfilmes.Business.Entidades;

namespace Netfilmes.Business.Servicos.Interfaces
{
    public interface IUsuarioService
    {
        bool Cadastrar(Usuario usuario);
        Usuario Buscar(Usuario usuario);
    }
}
