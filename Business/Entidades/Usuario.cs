using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}
