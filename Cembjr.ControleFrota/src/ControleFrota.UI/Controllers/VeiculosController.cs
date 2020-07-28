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
using Microsoft.AspNetCore.Razor.Language;
using AutoMapper;
using Cembjr.ControleFrota.Business.Entities;

namespace Cembjr.ControleFrota.UI.Controllers
{
    [Authorize]
    public class VeiculosController : Controller
    {

        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculosController(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }



        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ListarTodos()));
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            object veiculoViewModel = await ObterVeiculoPorId(id);

            if (veiculoViewModel == null)
                return NotFound();

            return View(veiculoViewModel);
        }

        private async Task<object> ObterVeiculoPorId(Guid id)
        {
            return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return View(veiculoViewModel);

            await _veiculoRepository.Adicionar(_mapper.Map<Veiculo>(veiculoViewModel));

            return RedirectToAction(nameof(Index));
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var veiculoViewModel = await ObterVeiculoPorId(id);

            if (veiculoViewModel == null)
                return NotFound();

            return View(veiculoViewModel);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VeiculoViewModel veiculoViewModel)
        {
            if (id != veiculoViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(veiculoViewModel);

            await _veiculoRepository.Atualizar(_mapper.Map<Veiculo>(veiculoViewModel));

            return RedirectToAction(nameof(Index));
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var veiculoViewModel = await ObterVeiculoPorId(id);

            if (veiculoViewModel == null)
                return NotFound();

            return View(veiculoViewModel);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var veiculoViewModel = await ObterVeiculoPorId(id);

            if (veiculoViewModel == null) return NotFound();

            await _veiculoRepository.Deletar(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
