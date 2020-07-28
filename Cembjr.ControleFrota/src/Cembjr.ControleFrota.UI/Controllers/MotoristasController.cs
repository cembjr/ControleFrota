using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cembjr.ControleFrota.UI.ViewModels;
using ControleFrota.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Cembjr.ControleFrota.Business.Interfaces;
using AutoMapper;
using Cembjr.ControleFrota.Business.Entities;

namespace Cembjr.ControleFrota.UI.Controllers
{
    [Authorize]
    public class MotoristasController : Controller
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMapper _mapper;

        public MotoristasController(IMotoristaRepository motoristaRepository, IMapper mapper)
        {
            _motoristaRepository = motoristaRepository;
            _mapper = mapper;
        }



        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ListarTodos()));
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            MotoristaViewModel motoristaViewModel = await ObterMotoristaPorId(id);
            if (motoristaViewModel == null)
                return NotFound();

            return View(motoristaViewModel);
        }

        private async Task<MotoristaViewModel> ObterMotoristaPorId(Guid id)
        {
            return _mapper.Map<MotoristaViewModel>(await _motoristaRepository.ObterPorId(id));
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return View(motoristaViewModel);

            var motorista = _mapper.Map<Motorista>(motoristaViewModel);
            await _motoristaRepository.Adicionar(motorista);

            return RedirectToAction(nameof(Index));
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var motoristaViewModel = await ObterMotoristaPorId(id);
            
            if (motoristaViewModel == null)
                return NotFound();
            
            return View(motoristaViewModel);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MotoristaViewModel motoristaViewModel)
        {
            if (id != motoristaViewModel.Id)
                return NotFound();
            

            if (!ModelState.IsValid) return View(motoristaViewModel);

            await _motoristaRepository.Atualizar(_mapper.Map<Motorista>(motoristaViewModel));
                
            return RedirectToAction(nameof(Index));            
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var motoristaViewModel = await ObterMotoristaPorId(id);
            if (motoristaViewModel == null)
                return NotFound();

            return View(motoristaViewModel);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motoristaViewModel = await ObterMotoristaPorId(id);

            if (motoristaViewModel == null) return NotFound();

            await _motoristaRepository.Deletar(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
