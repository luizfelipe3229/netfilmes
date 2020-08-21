using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Business.Entidades
{
    public class Genero
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Ativo { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}
