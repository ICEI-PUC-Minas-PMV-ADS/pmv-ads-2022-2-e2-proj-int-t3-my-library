using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Enum;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Minhas Reservas
        public async Task<IActionResult> MinhasReservas()
        {
            var applicationDbContext = _context.Reservas
                .Include(r => r.Livro)
                .Where(m => m.UsuarioId == UsuarioLogado.usuario.Id);
            return View(await applicationDbContext.ToListAsync());
        }
        
        // GET: Solicitações de Reservas
        public async Task<IActionResult> SolicitacoesReservas()
        {
            var applicationDbContext = _context.Reservas
                .Include(r => r.Livro)
                .Where(m => m.UsuarioId != UsuarioLogado.usuario.Id && m.Livro.BibliotecaId == UsuarioLogado.bibliotecaId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Meus Emprestimos
        public async Task<IActionResult> MeusEmprestimos()
        {
            var applicationDbContext = _context.Reservas
                .Include(l => l.Livro)
                .Where(r => 
                    r.UsuarioId == UsuarioLogado.usuario.Id 
                    && (r.Status != Status.Pendente)
                );
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Livros Emprestados
        public async Task<IActionResult> LivrosEmprestados()
        {
            var applicationDbContext = _context.Reservas
                .Include(r => r.Livro)
                .Where(r => 
                    r.UsuarioId != UsuarioLogado.usuario.Id 
                    && r.Livro.BibliotecaId == UsuarioLogado.bibliotecaId
                    && r.Status != Status.Pendente
                );
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservas.Include(r => r.Livro).Include(r => r.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public async Task<IActionResult> Create(int? id)
        {

            if (id == null || _context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.Include(l => l.Biblioteca).FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            ViewData["Livro"] = livro;

            return View();

        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,LivroId,DataInicio,DataFim,Status,AvaliacaoProprietario,AvaliacaoConsulente,DataDevolucaoAntecipada")] Reserva reserva)
        {

            reserva.UsuarioId = UsuarioLogado.usuario.Id;
            reserva.Status = Status.Pendente;

            _context.Add(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction("LivrosOutrosUsuarios", "Livros");

        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Autor", reserva.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,LivroId,DataInicio,DataFim,Status,AvaliacaoProprietario,AvaliacaoConsulente,DataDevolucaoAntecipada")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Autor", reserva.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservas'  is null.");
            }
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
          return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
