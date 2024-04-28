using Xunit;
using BibliotecaImpacta.Models;
using BibliotecaImpacta.Models.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotecaImpacta.Controllers;

namespace BibliotecaImpacta.Controllers
{
    public class CategoriaControllerTest
    {
        private CategoriasController _controller;
        private Context _context;

        public CategoriaControllerTest()
        {
            var options = new DbContextOptionsBuilder<Context>()
         .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
         .Options;

            _context = new Context(options);
            _controller = new CategoriasController(_context);
        }

        [Fact]
        public async Task TestIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestDetails()
        {
            var categoria = new Categoria { Id = 1, Descricao = "Teste" };
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            var result = await _controller.Details(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestCreate()
        {
            var categoria = new Categoria { Id = 1, Descricao = "Teste" };
            var result = await _controller.Create(categoria);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task TestEdit()
        {
            var categoria = new Categoria { Id = 1, Descricao = "Teste" };
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            categoria.Descricao = "Teste Editado";
            var result = await _controller.Edit(1, categoria);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task TestDelete()
        {
            var categoria = new Categoria { Id = 1, Descricao = "Teste" };
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            var result = await _controller.Delete(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestDeleteConfirmed()
        {
            var categoria = new Categoria { Id = 1, Descricao = "Teste" };
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            var result = await _controller.DeleteConfirmed(1);
            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}


