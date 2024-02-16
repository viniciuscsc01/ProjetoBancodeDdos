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
    public class PassagensController : Controller
    {
        private readonly Contexto _context;

        public PassagensController(Contexto context)
        {
            _context = context;
        }

        // GET: Passagens
        public async Task<IActionResult> Index()
        {
              return _context.Passagens != null ? 
                          View(await _context.Passagens.ToListAsync()) :
                          Problem("Entity set 'Contexto.Passagens'  is null.");
        }

        // GET: Passagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passagens == null)
            {
                return NotFound();
            }

            var passagens = await _context.Passagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagens == null)
            {
                return NotFound();
            }

            return View(passagens);
        }

        // GET: Passagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoId")] Passagens passagens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passagens);
        }

        // GET: Passagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passagens == null)
            {
                return NotFound();
            }

            var passagens = await _context.Passagens.FindAsync(id);
            if (passagens == null)
            {
                return NotFound();
            }
            return View(passagens);
        }

        // POST: Passagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoId")] Passagens passagens)
        {
            if (id != passagens.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagensExists(passagens.Id))
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
            return View(passagens);
        }

        // GET: Passagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passagens == null)
            {
                return NotFound();
            }

            var passagens = await _context.Passagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagens == null)
            {
                return NotFound();
            }

            return View(passagens);
        }

        // POST: Passagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passagens == null)
            {
                return Problem("Entity set 'Contexto.Passagens'  is null.");
            }
            var passagens = await _context.Passagens.FindAsync(id);
            if (passagens != null)
            {
                _context.Passagens.Remove(passagens);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagensExists(int id)
        {
          return (_context.Passagens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
