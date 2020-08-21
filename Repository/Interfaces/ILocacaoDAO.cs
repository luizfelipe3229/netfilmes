using Netfilmes.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Repository.Interfaces
{
    public interface ILocacaoDAO
    {
        int Cadastrar(Locacao locacao);
        List<Locacao> ListarTodos();
    }
}
