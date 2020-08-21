using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Entidades
{
    public class Locacao
    {
        public int Id { get; set; }

        public List<Filme> Filmes { get; set; }

        public string Cpf { get; set; }

        public DateTime DataDaLocacao { get; set; }
    }
}
