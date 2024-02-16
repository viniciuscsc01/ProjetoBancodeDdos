using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBancoDeDados.Models;
using ProjetoBancodeDdos.Models;

namespace ProjetoBancodeDados.Controllers
{
    public class InscricoesController : Controller
    {
        private readonly Contexto _context;

        public InscricoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Inscricoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Inscricoes.Include(i => i.Eventos).Include(i => i.PagamentoId).Include(i => i.Passagens).Include(i => i.Usuarios);
            return View(await contexto.ToListAsync());
        }

        // GET: Inscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Inscricoes
                .Include(i => i.Eventos)
                .Include(i => i.PagamentoId)
                .Include(i => i.Passagens)
                .Include(i => i.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricoes == null)
            {
                return NotFound();
            }

            return View(inscricoes);
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Inscricoes
                .Include(i => i.Eventos)
                .Include(i => i.PagamentoId)
                .Include(i => i.Passagens)
                .Include(i => i.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricoes == null)
            {
                return NotFound();
            }

            return View(inscricoes);
        }

        // GET: Inscricoes/Create
        public IActionResult Create()
        {
            ViewData["EventosId"] = new SelectList(_context.eventos, "Id", "Nome");
            ViewData["PagamentosId"] = new SelectList(_context.Pagamentos, "Id", "ValorId");
            ViewData["PassagensId"] = new SelectList(_context.Passagens, "Id", "DescricaoId");
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "NomeId");
            return View();
        }

        // POST: Inscricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventosId,PagamentosId,UsuariosId,PassagensId")] Inscricoes inscricoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventosId"] = new SelectList(_context.eventos, "Id", "Nome", inscricoes.EventosId);
            ViewData["PagamentosId"] = new SelectList(_context.Pagamentos, "Id", "ValorId", inscricoes.PagamentosId);
            ViewData["PassagensId"] = new SelectList(_context.Passagens, "Id", "DescricaoId", inscricoes.PassagensId);
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "NomeId", inscricoes.UsuariosId);
            return View(inscricoes);
        }

        // GET: Inscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Inscricoes.FindAsync(id);
            if (inscricoes == null)
            {
                return NotFound();
            }
            ViewData["EventosId"] = new SelectList(_context.eventos, "Id", "Nome", inscricoes.EventosId);
            ViewData["PagamentosId"] = new SelectList(_context.Pagamentos, "Id", "ValorId", inscricoes.PagamentosId);
            ViewData["PassagensId"] = new SelectList(_context.Passagens, "Id", "DescricaoId", inscricoes.PassagensId);
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "NomeId", inscricoes.UsuariosId);
            return View(inscricoes);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventosId,PagamentosId,UsuariosId,PassagensId")] Inscricoes inscricoes)
        {
            if (id != inscricoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricoesExists(inscricoes.Id))
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
            ViewData["EventosId"] = new SelectList(_context.eventos, "Id", "Nome", inscricoes.EventosId);
            ViewData["PagamentosId"] = new SelectList(_context.Pagamentos, "Id", "ValorId", inscricoes.PagamentosId);
            ViewData["PassagensId"] = new SelectList(_context.Passagens, "Id", "DescricaoId", inscricoes.PassagensId);
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "NomeId", inscricoes.UsuariosId);
            return View(inscricoes);
        }

        // GET: Inscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Inscricoes
                .Include(i => i.Eventos)
                .Include(i => i.PagamentoId)
                .Include(i => i.Passagens)
                .Include(i => i.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricoes == null)
            {
                return NotFound();
            }

            return View(inscricoes);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscricoes == null)
            {
                return Problem("Entity set 'Contexto.Inscricoes'  is null.");
            }
            var inscricoes = await _context.Inscricoes.FindAsync(id);
            if (inscricoes != null)
            {
                _context.Inscricoes.Remove(inscricoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricoesExists(int id)
        {
          return (_context.Inscricoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
