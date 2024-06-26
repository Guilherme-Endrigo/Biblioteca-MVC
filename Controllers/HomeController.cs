﻿using BibliotecaImpacta.Models;
using BibliotecaImpacta.Models.SqlContext;
using BibliotecaImpacta.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaImpacta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorio _repositorio;
       
        private readonly Context _context;


        public HomeController(ILogger<HomeController> logger, IRepositorio repositorio, Context context)
        {
            _logger = logger;
            _repositorio = repositorio;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {     
            var context = _context.Emprestimos.Include(p => p.Livro);
            return View(await context.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Emprestar()
        {
            ViewData["ClienteNome"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome");
            return View();
        }

    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Emprestar([Bind("Id, Nome, Telefone, Confirmado, LivroId")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Emprestimos, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }

        public IActionResult Emprestados()
        {
            var viewModel = new EmprestadosViewModel()
            {
                Emprestados = _context.Emprestimos.Include(x=> x.Livro),
                Search = string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Emprestados(EmprestadosViewModel viewModel)
        {
            viewModel.Emprestados = _context.Emprestimos;

            return View(viewModel);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome");
            return View(emprestimo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id, Nome, Telefone, Confirmado, LivroId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroId"] = new SelectList(_context.Emprestimos, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }
      
      
        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome");
            return View(emprestimo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id, [Bind("Id, Nome, Telefone, Confirmado, DataDevolucao, LivroId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroId"] = new SelectList(_context.Emprestimos, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }



    }
}
