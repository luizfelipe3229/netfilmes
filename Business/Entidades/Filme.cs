using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Entidades
{
    public class Filme
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Ativo { get; set; }

        public int? GeneroId { get; set; }
        public Genero Genero { get; set; }

        public int? LocacaoId { get; set; }
        public Locacao Locacao { get; set; }
    }
}
