using Netfilmes.Business.Entidades;
using System.Collections.Generic;

namespace Netfilmes.Business.Servicos.Interfaces
{
    public interface IGeneroService
    {
        bool Cadastrar(Genero genero);
        List<Genero> ListarTodos();
        bool RemoverSelecionados(List<int> generosId);
        Genero ConsultarPorId(int id);
        bool RemoverPorId(int id);
        List<Genero> ListarAtivos();
    }
}
