using Xunit;
using BibliotecaImpacta.Models;
using BibliotecaImpacta.Models.SqlContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestProject.RepositoryTest
{
    public class EmprestimoRepositoryTest
    {
        private Repositorio _repositorio;
        private Context _context;

        public EmprestimoRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new Context(options);
            _repositorio = new Repositorio(_context);
        }

        [Fact]
        public void TestAdicionaEmprestimo()
        {
            var emprestimo = new Emprestimo
            {
                Nome = "Teste",
                Telefone = "1234567890",
                Confirmado = true
            };
            _repositorio.AdicionaEmprestimo(emprestimo);

            Assert.Equal(1, _context.Emprestimos.Count());
            Assert.Equal(emprestimo, _context.Emprestimos.Single());
        }

        [Fact]
        public void TestUpdate()
        {
            var emprestimo = new Emprestimo
            {
                Nome = "TesteUpdate",
                Telefone = "1234567890",
                Confirmado = true
            };
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            emprestimo.Nome = "Depois";
            _repositorio.Update(emprestimo);

            var updatedEmprestimo = _context.Emprestimos.FirstOrDefault(e => e.Id == emprestimo.Id);
            Assert.Equal("Depois", updatedEmprestimo.Nome);
        }

        [Fact]
        public void TestRemove()
        {
            var emprestimo = new Emprestimo
            {
                Nome = "Teste",
                Telefone = "1234567890",
                Confirmado = true
            };
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            _repositorio.Remove(emprestimo);

            Assert.Empty(_context.Emprestimos);
        }
    }
}