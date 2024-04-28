using BibliotecaImpacta.Models;

namespace TestProject.ModelsTest
{
    public class CategoriaModelTest
    {
        private Categoria _categoria;

        public CategoriaModelTest()
        {
            _categoria = new Categoria();
        }

        [Fact]
        public void TestIdProperty()
        {
            int testValue = 1;
            _categoria.Id = testValue;
            Assert.Equal(testValue, _categoria.Id);
        }

        [Fact]
        public void TestDescricaoProperty()
        {
            string testValue = "Teste";
            _categoria.Descricao = testValue;
            Assert.Equal(testValue, _categoria.Descricao);
        }
    }
}

