using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Livros do Usuario
        public async Task<IActionResult> LivrosDoUsuario(string searchString)
        {
            var applicationDbContext =  _context.Livros
                .Include(l => l.Biblioteca)
                .Where(l => 
                    l.BibliotecaId == UsuarioLogado.bibliotecaId 
                    && (
                        String.IsNullOrEmpty(searchString) 
                        || (
                            !String.IsNullOrEmpty(searchString) 
                            && (
                                l.Nome.ToLower().IndexOf(searchString.ToLower()) != -1 
                                || l.Autor.ToLower().IndexOf(searchString.ToLower()) != -1
                            )
                        )
                    )
                );

            ViewData["NomeBiblioteca"] = (await _context.Bibliotecas.FirstOrDefaultAsync(b => b.Id == UsuarioLogado.bibliotecaId)).Nome;

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Livros de Outros Usuarios
        public async Task<IActionResult> LivrosOutrosUsuarios(string searchString)
        {
            var applicationDbContext = _context.Livros
                .Include(l => l.Biblioteca)
                .Where(l =>
                    l.BibliotecaId != UsuarioLogado.bibliotecaId
                    && l.Biblioteca.Compartilhar
                    && l.Emprestar
                    && (
                        String.IsNullOrEmpty(searchString)
                        || (
                            !String.IsNullOrEmpty(searchString)
                            && (
                                l.Nome.ToLower().IndexOf(searchString.ToLower()) != -1
                                || l.Autor.ToLower().IndexOf(searchString.ToLower()) != -1
                                || l.Biblioteca.Nome.ToLower().IndexOf(searchString.ToLower()) != -1
                            )
                        )
                    )
                );

            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Livros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Livros.Include(l => l.Biblioteca);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Biblioteca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["BibliotecaId"] = UsuarioLogado.bibliotecaId;
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BibliotecaId,Nome,Autor,Titulo,Ano,Genero,Editora,Paginas,ISBN,Local,Emprestar")] Livro livro)
        {

            livro.Biblioteca = await _context.Bibliotecas.FindAsync(livro.BibliotecaId);

            _context.Add(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["BibliotecaId"] = new SelectList(_context.Bibliotecas, "Id", "Id", livro.BibliotecaId);

            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["BibliotecaId"] = new SelectList(_context.Bibliotecas, "Id", "Id", livro.BibliotecaId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BibliotecaId,Nome,Autor,Titulo,Ano,Genero,Editora,Paginas,ISBN,Local,Emprestar")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            ViewData["BibliotecaId"] = new SelectList(_context.Bibliotecas, "Id", "Id", livro.BibliotecaId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Biblioteca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Livros'  is null.");
            }
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("LivrosDoUsuario", "Livros");
        }

        private bool LivroExists(int id)
        {
          return _context.Livros.Any(e => e.Id == id);
        }
    }
}
