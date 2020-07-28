using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cembjr.ControleFrota.UI.ViewModels;
using ControleFrota.UI.Data;
using Cembjr.ControleFrota.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Razor.Language;
using Cembjr.ControleFrota.Business.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Cembjr.ControleFrota.UI.Controllers
{
    [Authorize]
    public class AtendentesController : Controller
    {
        private readonly IAtendenteRepository _atendenteRepository;
        private readonly IMapper _mapper;

        public AtendentesController(IAtendenteRepository atendenteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _atendenteRepository = atendenteRepository;
        }

        // GET: Atendentes
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AtendenteViewModel>>(await _atendenteRepository.ListarTodos()));
        }

        // GET: Atendentes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var atendenteViewModel = _mapper.Map<AtendenteViewModel>(await _atendenteRepository.ObterPorId(id));

            if (atendenteViewModel == null)
                return NotFound();
            
            return View(atendenteViewModel);
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
        public async Task<IActionResult> Create(AtendenteViewModel atendenteViewModel)
        {
            if (!ModelState.IsValid) return View(atendenteViewModel);

            await _atendenteRepository.Adicionar(_mapper.Map<Atendente>(atendenteViewModel));
    
            return RedirectToAction(nameof(Index));
        }

        // GET: Atendentes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var atendenteViewModel = _mapper.Map<AtendenteViewModel>(await _atendenteRepository.ObterPorId(id));

            if (atendenteViewModel == null)
                return NotFound();

            return View(atendenteViewModel);
        }

        // POST: Atendentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AtendenteViewModel atendenteViewModel)
        {
            if (id != atendenteViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(atendenteViewModel);

            var atentende = _mapper.Map<Atendente>(atendenteViewModel);
            await _atendenteRepository.Atualizar(atentende);
            
            return RedirectToAction(nameof(Index));            
        }

        // GET: Atendentes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var atendenteViewModel = _mapper.Map<AtendenteViewModel>(await _atendenteRepository.ObterPorId(id));

            if (atendenteViewModel == null)
                return NotFound();
            
            return View(atendenteViewModel);
        }

        // POST: Atendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var atendente = _atendenteRepository.ObterPorId(id);
            
            if (atendente == null) return NotFound();

            await _atendenteRepository.Deletar(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
