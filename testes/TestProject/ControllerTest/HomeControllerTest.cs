using BibliotecaImpacta.Models.SqlContext;
using BibliotecaImpacta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics;
using BibliotecaImpacta.ViewModels;

namespace BibliotecaImpacta.Controllers
{
    public class HomeControllerTest
    {
        private HomeController _controller;
        private Context _context;
        private Mock<ILogger<HomeController>> _logger;
        private Mock<IRepositorio> _repositorio;

        public HomeControllerTest()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new Context(options);
            _logger = new Mock<ILogger<HomeController>>();
            _repositorio = new Mock<IRepositorio>();
            _controller = new HomeController(_logger.Object, _repositorio.Object, _context);
        }

        [Fact]
        public async Task TestIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestPrivacy()
        {
            var result = _controller.Privacy();
            Assert.IsType<ViewResult>(result);
        }
    

        [Fact]
        public void TestEmprestar()
        {
            var result = _controller.Emprestar();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestEmprestarCompleto()
        {
            var emprestimo = new Emprestimo { Id = 1, Nome = "Teste", Telefone = "1234567890", Confirmado = true, LivroId = 1 };
            var result = await _controller.Emprestar(emprestimo);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void TestEmprestados()
        {
            var result = _controller.Emprestados();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestEmprestadosPost()
        {
            var viewModel = new EmprestadosViewModel();
            var result = _controller.Emprestados(viewModel);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestEditar()
        {
            var emprestimo = new Emprestimo { Id = 1, Nome = "Teste", Telefone = "1234567890", Confirmado = true, LivroId = 1 };
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            var result = await _controller.Editar(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestEditarPost()
        {
            var emprestimo = new Emprestimo { Id = 1, Nome = "Teste", Telefone = "1234567890", Confirmado = true, LivroId = 1 };
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            var result = await _controller.Editar(1, emprestimo);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
