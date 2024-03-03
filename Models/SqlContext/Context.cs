using Microsoft.EntityFrameworkCore;
using System;

namespace BibliotecaImpacta.Models.SqlContext
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } //Uma tabela chamada Categorias
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria[]
                {
                    new Categoria {Id=1, Descricao= "Terror",},
                    new Categoria {Id=2, Descricao= "Infanto Juvenil"},
                     new Categoria {Id=3,  Descricao= "Romance"},
                     new Categoria {Id=4,  Descricao= "Auto Ajuda"}
                }
            );

            modelBuilder.Entity<Livro>().HasData(
                new Livro[]
                {
                    new Livro {Id=1, Nome= "Revolução dos Bichos", Autor ="George Orwell", Editora="Companhia das Letras", Ano=2021, CategoriaId=2},
                    new Livro {Id=2, Nome= "O poder do hábito", Autor ="Charles Duhigg", Editora="Objetiva", Ano=2012, CategoriaId=4},
                    new Livro {Id=3, Nome= "A garota do lago", Autor ="Charlie Donlea", Editora="Faro Editorial", Ano=2017, CategoriaId=1}
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=BibliotecaImpacta;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        public void SetModified(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
