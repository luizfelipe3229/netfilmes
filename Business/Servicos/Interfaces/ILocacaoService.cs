using Netfilmes.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Servicos.Interfaces
{
    public interface ILocacaoService
    {
        bool Cadastrar(Locacao locacao, List<int> filmesId);
        List<Locacao> ListarTodos();
        bool Desalocar(List<int> filmesId);
    }
}
