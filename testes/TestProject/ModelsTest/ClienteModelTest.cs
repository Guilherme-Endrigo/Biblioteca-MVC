using Xunit;
using BibliotecaImpacta.Models;

namespace TestProject.ModelsTest
{
    public class ClienteModelTest
    {
        private Cliente _cliente;

        public ClienteModelTest()
        {
            _cliente = new Cliente();
        }

        [Fact]
        public void TestIdProperty()
        {
            int testValue = 1;
            _cliente.Id = testValue;
            Assert.Equal(testValue, _cliente.Id);
        }

        [Fact]
        public void TestNomeProperty()
        {
            string testValue = "Teste";
            _cliente.Nome = testValue;
            Assert.Equal(testValue, _cliente.Nome);
        }

        [Fact]
        public void TestTelefoneProperty()
        {
            string testValue = "1234567890";
            _cliente.Telefone = testValue;
            Assert.Equal(testValue, _cliente.Telefone);
        }

        [Fact]
        public void TestEnderecoProperty()
        {
            string testValue = "Rua Teste, 123";
            _cliente.Endereço = testValue;
            Assert.Equal(testValue, _cliente.Endereço);
        }

        [Fact]
        public void TestIdadeProperty()
        {
            int testValue = 30;
            _cliente.Idade = testValue;
            Assert.Equal(testValue, _cliente.Idade);
        }

        [Fact]
        public void TestCategoriaIdProperty()
        {
            int testValue = 1;
            _cliente.CategoriaId = testValue;
            Assert.Equal(testValue, _cliente.CategoriaId);
        }

        [Fact]
        public void TestCategoriaProperty()
        {
            var testValue = new Categoria { Id = 1, Descricao = "Teste" };
            _cliente.Categoria = testValue;
            Assert.Equal(testValue, _cliente.Categoria);
        }
    }
}

