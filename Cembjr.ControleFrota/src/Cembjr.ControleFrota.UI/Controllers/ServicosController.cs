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
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using System.ComponentModel;

namespace Cembjr.ControleFrota.UI.Controllers
{
    [Authorize]
    public class ServicosController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IServicoRepository _servicoRepository;
        private readonly IAtendenteRepository _atendenteRepository;
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public ServicosController(IMapper mapper, IServicoRepository servicoRepository, IAtendenteRepository atendenteRepository, IMotoristaRepository motoristaRepository, IVeiculoRepository veiculoRepository)
        {
            _mapper = mapper;
            _servicoRepository = servicoRepository;
            _atendenteRepository = atendenteRepository;
            _motoristaRepository = motoristaRepository;
            _veiculoRepository = veiculoRepository;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ServicoViewModel>>(await _servicoRepository.ListarTodos())); ;
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var servicoViewModel = await ObterServicoPorId(id);

            if (servicoViewModel == null)
                return NotFound();


            return View(servicoViewModel);
        }

        private async Task<ServicoViewModel> ObterServicoPorId(Guid id)
        {
            return _mapper.Map<ServicoViewModel>(await _servicoRepository.ObterPorId(id));
        }

        // GET: Servicos/Create
        public async Task<IActionResult> Create()
        {
            var sericoViewModel = await CarregarListas();

            return View(sericoViewModel);
        }

        private async Task<ServicoViewModel> CarregarListas(ServicoViewModel servicoViewModel = null)
        {
            if (servicoViewModel == null)
                servicoViewModel = new ServicoViewModel();

            servicoViewModel.Atendentes = _mapper.Map<IEnumerable<AtendenteViewModel>>(await _atendenteRepository.ListarTodos());
            servicoViewModel.Veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ListarTodos());
            servicoViewModel.Motoristas = _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ListarTodos());

            return servicoViewModel;
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicoViewModel servicoViewModel)
        {
            if (!ModelState.IsValid)
            {
                await CarregarListas(servicoViewModel);
                return View(servicoViewModel);
            }

            await _servicoRepository.Adicionar(_mapper.Map<Servico>(servicoViewModel));

            return RedirectToAction(nameof(Index));

        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var servicoViewModel = await ObterServicoPorId(id);

            if (servicoViewModel == null)
                return NotFound();

            await CarregarListas(servicoViewModel);

            return View(servicoViewModel);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await CarregarListas(servicoViewModel);
                return View(servicoViewModel);
            }

            await _servicoRepository.Atualizar(_mapper.Map<Servico>(servicoViewModel));
            return RedirectToAction(nameof(Index));

        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var servicoViewModel = await ObterServicoPorId(id);
            if (servicoViewModel == null)
                return NotFound();

            return View(servicoViewModel);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var servicoViewModel = await ObterServicoPorId(id);

            if (servicoViewModel == null) return NotFound();

            await _servicoRepository.Deletar(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
