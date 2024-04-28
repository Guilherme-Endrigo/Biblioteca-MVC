using BibliotecaImpacta.Models;

namespace TestProject.ModelsTest
{
    public class LivroModelTest
    {
        private Livro _livro;

        public LivroModelTest()
        {
            _livro = new Livro();
        }

        [Fact]
        public void TestIdProperty()
        {
            int testValue = 1;
            _livro.Id = testValue;
            Assert.Equal(testValue, _livro.Id);
        }

        [Fact]
        public void TestNomeProperty()
        {
            string testValue = "Teste";
            _livro.Nome = testValue;
            Assert.Equal(testValue, _livro.Nome);
        }

        [Fact]
        public void TestAutorProperty()
        {
            string testValue = "Autor Teste";
            _livro.Autor = testValue;
            Assert.Equal(testValue, _livro.Autor);
        }

        [Fact]
        public void TestEditoraProperty()
        {
            string testValue = "Editora Teste";
            _livro.Editora = testValue;
            Assert.Equal(testValue, _livro.Editora);
        }

        [Fact]
        public void TestAnoProperty()
        {
            int testValue = 2022;
            _livro.Ano = testValue;
            Assert.Equal(testValue, _livro.Ano);
        }

        [Fact]
        public void TestCategoriaIdProperty()
        {
            int testValue = 1;
            _livro.CategoriaId = testValue;
            Assert.Equal(testValue, _livro.CategoriaId);
        }

        [Fact]
        public void TestCategoriaProperty()
        {
            var testValue = new Categoria { Id = 1, Descricao = "Teste" };
            _livro.Categoria = testValue;
            Assert.Equal(testValue, _livro.Categoria);
        }
    }
}