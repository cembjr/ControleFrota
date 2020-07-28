using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cembjr.ControleFrota.Business.Entities;
using Cembjr.ControleFrota.Data.Context;

namespace Cembjr.ControleFrota.App.Controllers
{
    public class AtendentesController : Controller
    {
        private readonly ControleFrotaContext _context;

        public AtendentesController(ControleFrotaContext context)
        {
            _context = context;
        }

        // GET: Atendentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atendentes.ToListAsync());
        }

        // GET: Atendentes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendente == null)
            {
                return NotFound();
            }

            return View(atendente);
        }

        // GET: Atendentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atendentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Telefone,Id,DataCadastro,IsExcluido")] Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atendente);
        }

        // GET: Atendentes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendentes.FindAsync(id);
            if (atendente == null)
            {
                return NotFound();
            }
            return View(atendente);
        }

        // POST: Atendentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Telefone,Id,DataCadastro,IsExcluido")] Atendente atendente)
        {
            if (id != atendente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendenteExists(atendente.Id))
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
            return View(atendente);
        }

        // GET: Atendentes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendente == null)
            {
                return NotFound();
            }

            return View(atendente);
        }

        // POST: Atendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var atendente = await _context.Atendentes.FindAsync(id);
            _context.Atendentes.Remove(atendente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendenteExists(Guid id)
        {
            return _context.Atendentes.Any(e => e.Id == id);
        }
    }
}
