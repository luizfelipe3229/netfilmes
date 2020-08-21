using Netfilmes.Business.Entidades;
using System.Collections.Generic;

namespace Netfilmes.Repository.Interfaces
{
    public interface IGeneroDAO
    {
        bool Cadastrar(Genero genero);
        List<Genero> ListarTodos();
        bool RemoverSelecionados(List<Genero> generos);
        Genero ConsultarPorId(int id);
        bool RemoverPorId(int id);
        List<Genero> ListarAtivos();
    }
}
