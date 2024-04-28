using Xunit;
using BibliotecaImpacta.Models;
using System;

namespace TestProject.ModelsTest
{
    public class EmprestimoModelTest
    {
        private Emprestimo _emprestimo;

        public EmprestimoModelTest()
        {
            _emprestimo = new Emprestimo();
        }

        [Fact]
        public void TestIdProperty()
        {
            int testValue = 1;
            _emprestimo.Id = testValue;
            Assert.Equal(testValue, _emprestimo.Id);
        }

        [Fact]
        public void TestNomeProperty()
        {
            string testValue = "Teste";
            _emprestimo.Nome = testValue;
            Assert.Equal(testValue, _emprestimo.Nome);
        }

        [Fact]
        public void TestTelefoneProperty()
        {
            string testValue = "1234567890";
            _emprestimo.Telefone = testValue;
            Assert.Equal(testValue, _emprestimo.Telefone);
        }

        [Fact]
        public void TestConfirmadoProperty()
        {
            bool? testValue = true;
            _emprestimo.Confirmado = testValue;
            Assert.Equal(testValue, _emprestimo.Confirmado);
        }

        [Fact]
        public void TestDataDevolucaoProperty()
        {
            DateTime? testValue = DateTime.Now;
            _emprestimo.DataDevolucao = testValue;
            Assert.Equal(testValue, _emprestimo.DataDevolucao);
        }

        [Fact]
        public void TestLivroIdProperty()
        {
            int testValue = 1;
            _emprestimo.LivroId = testValue;
            Assert.Equal(testValue, _emprestimo.LivroId);
        }

        [Fact]
        public void TestLivroProperty()
        {
            var testValue = new Livro { Id = 1, Nome = "Teste" };
            _emprestimo.Livro = testValue;
            Assert.Equal(testValue, _emprestimo.Livro);
        }
    }
}

