using Netfilmes.Business.Entidades;
using System.Collections.Generic;

namespace Netfilmes.Business.Servicos.Interfaces
{
    public interface IFilmeService
    {
        bool Cadastrar(Filme filme);
        Filme ConsultarPorId(int id);
        List<Filme> ListarTodos();
        List<Filme> ListarNaoLocados();
        bool RemoverSelecionados(List<int> filmesId);
        bool RemoverPorId(int id);
    }
}
