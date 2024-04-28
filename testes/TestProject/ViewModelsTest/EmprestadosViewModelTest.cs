using BibliotecaImpacta.Models;
using BibliotecaImpacta.ViewModels;
namespace TestProject.ViewModelsTest
{
    public class EmprestadosViewModelTest
    {
        [Fact]
        public void TestEmprestadosViewModel()
        {
            var emprestimos = new List<Emprestimo>
        {
            new Emprestimo { Id = 1, Nome = "Teste", Telefone = "1234567890", Confirmado = true, LivroId = 1 },
            new Emprestimo { Id = 2, Nome = "Teste 2", Telefone = "0987654321", Confirmado = false, LivroId = 2 }
        };

            var viewModel = new EmprestadosViewModel
            {
                Search = "Teste",
                Emprestados = emprestimos
            };

            Assert.Equal("Teste", viewModel.Search);
            Assert.Equal(2, viewModel.Emprestados.Count());
        }
    }
}
