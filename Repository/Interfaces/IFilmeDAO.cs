using Netfilmes.Business.Entidades;
using System.Collections.Generic;

namespace Netfilmes.Repository.Interfaces
{
    public interface IFilmeDAO
    {
        bool Cadastrar(Filme filme);
        Filme ConsultarPorId(int id);
        List<Filme> ListarTodos();
        List<Filme> ListarNaoLocados();
        bool RemoverSelecionados(List<Filme> filmes);
        bool RemoverPorId(int id);
    }
}
