using Microsoft.EntityFrameworkCore;
using Netfilmes.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfilmes.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LFPC\\SQLEXPRESS;Initial Catalog=Netfilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define um valor padrão para a propriedade DataDeCriacao da entidade Filme
            modelBuilder.Entity<Filme>().Property(filme => filme.DataDeCriacao).HasDefaultValueSql("CONVERT(DATE, GETDATE())");

            // Define que quando um Genero for excluido, os filmes ligados a ele não serão excluidos
            modelBuilder.Entity<Filme>().HasOne(filme => filme.Genero).WithMany(genero => genero.Filmes).OnDelete(DeleteBehavior.SetNull);

            // Define um valor padrão para a propriedade DataDeCriacao da entidade Genero
            modelBuilder.Entity<Genero>().Property(genero => genero.DataDeCriacao).HasDefaultValueSql("CONVERT(DATE, GETDATE())");

            // Define um valor padrão para a propriedade DataDaLocacao da entidade Locacao
            modelBuilder.Entity<Locacao>().Property(locacao => locacao.DataDaLocacao).HasDefaultValueSql("CONVERT(DATE, GETDATE())");

            // Define um valor padrão para a propriedade DataDeCriacao da entidade Usuario
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.DataDeCriacao).HasDefaultValueSql("CONVERT(DATE, GETDATE())");

        }
    }
}
