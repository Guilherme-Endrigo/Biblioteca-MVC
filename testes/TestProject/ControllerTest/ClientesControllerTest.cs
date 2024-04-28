using BibliotecaImpacta.Models;
using BibliotecaImpacta.Models.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaImpacta.Controllers
{
    public class ClientesControllerTest
    {
        private ClientesController _controller;
        private Context _context;

        public ClientesControllerTest()
        {
            var options = new DbContextOptionsBuilder<Context>()
          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
          .Options;

            _context = new Context(options);
            _controller = new ClientesController(_context);
        }

        [Fact]
        public async Task TestIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestCreate()
        {
            var cliente = new Cliente { Id = 1, Nome = "Teste", Telefone = "1234567890", Endereço = "Rua Teste, 123", Idade = 30, CategoriaId = 1 };
            var result = await _controller.Create(cliente);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task TestEdit()
        {
            var cliente = new Cliente { Id = 1, Nome = "Teste", Telefone = "1234567890", Endereço = "Rua Teste, 123", Idade = 30, CategoriaId = 1 };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            cliente.Nome = "Teste Editado";
            var result = await _controller.Edit(1, cliente);
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact]
        public async Task TestDeleteConfirmed()
        {
            var cliente = new Cliente { Id = 1, Nome = "Teste", Telefone = "1234567890", Endereço = "Rua Teste, 123", Idade = 30, CategoriaId = 1 };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var result = await _controller.DeleteConfirmed(1);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void TestClienteExists()
        {
            var cliente = new Cliente { Id = 1, Nome = "Teste", Telefone = "1234567890", Endereço = "Rua Teste, 123", Idade = 30, CategoriaId = 1 };
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            var exists = _controller.ClienteExists(1);
            Assert.True(exists);
        }

    }
}

