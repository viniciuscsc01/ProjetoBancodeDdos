﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBancodeDados.Models;
using ProjetoBancodeDdos.Models;

namespace ProjetoBancodeDados.Controllers
{
    public class EventosController : Controller
    {
        private readonly Contexto _context;

        public EventosController(Contexto context)
        {
            _context = context;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
              return _context.eventos != null ? 
                          View(await _context.eventos.ToListAsync()) :
                          Problem("Entity set 'Contexto.eventos'  is null.");
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.eventos == null)
            {
                return NotFound();
            }

            var eventos = await _context.eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataCriacao,DataAtualizacao,Criacao")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.eventos == null)
            {
                return NotFound();
            }

            var eventos = await _context.eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataCriacao,DataAtualizacao,Criacao")] Eventos eventos)
        {
            if (id != eventos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosExists(eventos.Id))
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
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.eventos == null)
            {
                return NotFound();
            }

            var eventos = await _context.eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.eventos == null)
            {
                return Problem("Entity set 'Contexto.eventos'  is null.");
            }
            var eventos = await _context.eventos.FindAsync(id);
            if (eventos != null)
            {
                _context.eventos.Remove(eventos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventosExists(int id)
        {
          return (_context.eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
