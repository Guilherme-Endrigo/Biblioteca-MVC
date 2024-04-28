using BibliotecaImpacta.Controllers;
using BibliotecaImpacta.Models.SqlContext;
using BibliotecaImpacta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaImpacta.Controllers
{
    public class LivroControllerTest
    {
        private LivrosController _controller;
        private Context _context;

        public LivroControllerTest()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new Context(options);
            _controller = new LivrosController(_context);
        }

        [Fact]
        public async Task TestIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestCreate()
        {
            var result = _controller.Create();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestCreatePost()
        {
            var livro = new Livro { Id = 1, Nome = "Teste", Autor = "Autor Teste", Editora = "Editora Teste", Ano = 2024, CategoriaId = 1 };
            var result = await _controller.Create(livro);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task TestEdit()
        {
            var livro = new Livro { Id = 1, Nome = "Teste", Autor = "Autor Teste", Editora = "Editora Teste", Ano = 2024, CategoriaId = 1 };
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            var result = await _controller.Edit(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestEditPost()
        {
            var livro = new Livro { Id = 1, Nome = "Teste", Autor = "Autor Teste", Editora = "Editora Teste", Ano = 2024, CategoriaId = 1 };
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            var result = await _controller.Edit(1, livro);
            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}



