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


        // GET: Minhas Reservas -- coloquei o filtro para testar (VOLTAR AQUI PARA CHECAR SE TA OK)
        public async Task<IActionResult> MinhasReservas(string searchString)
        {
            var applicationDbContext = _context.Reservas
                .Include(r => r.Livro)
                .Where(m =>
                    m.UsuarioId == UsuarioLogado.usuario.Id
                    && (m.Status == Status.Pendente || m.Status == Status.Cancelado)
                    && (
                        String.IsNullOrEmpty(searchString)
                            ||(
                                !String.IsNullOrEmpty(searchString)
                            )
                            &&(
                                 m.Livro.Nome.ToLower().IndexOf(searchString.ToLower()) != -1
                                 || m.Livro.Autor.ToLower().IndexOf(searchString.ToLower()) != -1

                            )
                        )
                    
                 );

            return View(await applicationDbContext.ToListAsync());
        }
        
        // GET: Solicitações de Reservas
        public async Task<IActionResult> SolicitacoesReservas(string searchString)
        {
            var applicationDbContext = _context.Reservas
                .Include(r => r.Livro)
                .Where(m => m.UsuarioId != UsuarioLogado.usuario.Id && m.Livro.BibliotecaId == UsuarioLogado.bibliotecaId && (m.Status == Status.Pendente)
                && (
                        String.IsNullOrEmpty(searchString)
                            || (
                                !String.IsNullOrEmpty(searchString)
                            )
                            && (
                                 m.Livro.Nome.ToLower().IndexOf(searchString.ToLower()) != -1
                                 || m.Livro.Autor.ToLower().IndexOf(searchString.ToLower()) != -1

                            )
                        )
                );
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Meus Emprestimos
        public async Task<IActionResult> MeusEmprestimos(string searchString)
        {
            var applicationDbContext = _context.Reservas
                .Include(l => l.Livro)
                .Where(r => 
                    r.UsuarioId == UsuarioLogado.usuario.Id 
                    && (r.Status != Status.Pendente)
                    && (
                        String.IsNullOrEmpty(searchString)
                            || (
                                !String.IsNullOrEmpty(searchString)
                            )
                            && (
                                 r.Livro.Nome.ToLower().IndexOf(searchString.ToLower()) != -1
                                 || r.Livro.Autor.ToLower().IndexOf(searchString.ToLower()) != -1

                            )
                        )
                );
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Livros Emprestados
        public async Task<IActionResult> LivrosEmprestados(string searchString) {
            var applicationDbContext = _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Livro.Biblioteca)
                .Where(r =>
                    r.UsuarioId != UsuarioLogado.usuario.Id
                    && r.Livro.BibliotecaId == UsuarioLogado.bibliotecaId
                    && r.Status != Status.Pendente
                    && r.Status != Status.Cancelado
                    && (
                        String.IsNullOrEmpty(searchString)
                            || (
                                !String.IsNullOrEmpty(searchString)
                            )
                            && (
                                 r.Livro.Nome.ToLower().IndexOf(searchString.ToLower()) != -1
                                 || r.Livro.Autor.ToLower().IndexOf(searchString.ToLower()) != -1

                            )
                        )

                 );

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SolicitarDevolucao
        public async Task<IActionResult> AcaoSolicitarDevolucao(int id, string telaOrigem, int origem)
        {

            if (telaOrigem == null || origem == 0)
            {
                return NotFound();
            }

            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Livro.Biblioteca)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            ViewData["Livro"] = reserva.Livro;
            ViewData["Id"] = id;
            ViewData["Origem"] = origem;
            ViewData["TelaOrigem"] = telaOrigem;

            return View(reserva);

        }

        // POST: SolicitarDevolucao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcaoSolicitarDevolucao(int origem, string telaOrigem, [Bind("Id")] Reserva reserva)
        {

            var r = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == reserva.Id);

            r.Status = origem == 1 ? Status.ConsulenteDev : Status.ProprietarioDev;

            _context.Update(r);

            await _context.SaveChangesAsync();

            return RedirectToAction("MeusEmprestimos", "Reservas");

        }

        // GET: AvaliarEmprestimo
        public async Task<IActionResult> AcaoAvaliarEmprestimo(int id, string telaOrigem, int origem)
        {

            if (telaOrigem == null || origem == 0)
            {
                return NotFound();
            }

            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Livro.Biblioteca)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            ViewData["Livro"] = reserva.Livro;
            ViewData["Id"] = id;
            ViewData["Origem"] = origem;
            ViewData["TelaOrigem"] = telaOrigem;

            return View(reserva);

        }

        // POST: AcaoAvaliarEmprestimo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcaoAvaliarEmprestimo(int origem, string telaOrigem, [Bind("Id,AvaliacaoConsulente,AvaliacaoProprietario")] Reserva reserva)
        {

            var r = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == reserva.Id);

            // CONSULENTE
            if (origem == 1)
            {
                r.AvaliacaoConsulente = reserva.AvaliacaoConsulente;
            } else // PROPRIETARIO
            {
                r.AvaliacaoProprietario = reserva.AvaliacaoProprietario;
            }

            _context.Update(r);

            await _context.SaveChangesAsync();

            return RedirectToAction(telaOrigem, "Reservas");

        }

        // GET: AcaoCancelarReserva
        public async Task<IActionResult> AcaoCancelarReserva(int id)
        {

            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Livro.Biblioteca)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            ViewData["Livro"] = reserva.Livro;
            ViewData["Id"] = id;

            return View(reserva);

        }

        // POST: AcaoCancelarReserva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcaoCancelarReserva([Bind("Id")] Reserva reserva)
        {

            var r = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == reserva.Id);

            r.Status = Status.Cancelado;

            _context.Update(r);

            await _context.SaveChangesAsync();

            return RedirectToAction("MinhasReservas", "Reservas");

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



        // ALTERAR STATUS DO LIVRO COM A PROVAÇÃO DE RESERVA//////////////////////////////////////////////////////////////////////////////////////////////


        public async Task<IActionResult> EditStatus(int? id)
        {
           

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Autor", reserva.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatus (int id, [Bind("Id,Status")] Reserva reserva)
        {

            var r = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == reserva.Id);
            
            r.Status = Status.Efetivado; 

            _context.Update(r);
           
            await _context.SaveChangesAsync();
            
            return RedirectToAction("LivrosEmprestados", "Reservas");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatusCancelar(int id, [Bind("Id,Status")] Reserva reserva)
        {

            var r = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == reserva.Id);

            r.Status = Status.Cancelado;

            _context.Update(r);

            await _context.SaveChangesAsync();

            return RedirectToAction("LivrosEmprestados", "Reservas");

        }


        //////////////////////////////////////////////////////////////////////////////////////////////

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
