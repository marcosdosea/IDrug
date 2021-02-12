using AutoMapper;
using Core;
using Core.Service;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Controllers
{
    public class DisponibilizarMedicamentoController : Controller
    {
        IDisponibilizarMedicamentoService _disponibilizarMedicamentoService;
        IFarmaciaService _farmaciaService;
        IMedicamentoService _medicamentoService;
        IMapper _mapper;

        public DisponibilizarMedicamentoController(IDisponibilizarMedicamentoService disponibilizarMedicamentoService, IMedicamentoService medicamentoService, IFarmaciaService farmaciaService, IMapper mapper)
        {
            _disponibilizarMedicamentoService = disponibilizarMedicamentoService;
            _medicamentoService = medicamentoService;
            _farmaciaService = farmaciaService;
            _mapper = mapper;
        }

        // GET: DisponibilizarMedicamentoController
        public ActionResult Index()
        {
            var listaDisponibilizacaoMedicamentos = _disponibilizarMedicamentoService.ObterTodos();
            var listaDisponibilizacaoMedicamentosModel = _mapper.Map<List<DisponibilizarMedicamentoModel>>(listaDisponibilizacaoMedicamentos);
            return View(listaDisponibilizacaoMedicamentosModel);
        }

        // GET: DisponibilizarMedicamentoController/Details/5
        public ActionResult Details(int id)
        {
            Medicamentodisponivel medicamento = _disponibilizarMedicamentoService.Obter(id);
            DisponibilizarMedicamentoModel disponibilizarMedicamentoModel = _mapper.Map<DisponibilizarMedicamentoModel>(medicamento);
            return View(disponibilizarMedicamentoModel);
        }

        // GET: DisponibilizarMedicamentoController/Create
        public ActionResult Create()
        {
            IEnumerable<Medicamento> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<Farmacia> listaFarmacias = _farmaciaService.ObterTodos();

            ViewBag.IdMedicamento = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.IdFarmacia = new SelectList(listaFarmacias, "IdFarmacia", "Nome", null);

            return View();
        }
        // TODO: obter ano e mês a partir de data de validade e aicioná - los aos campos, Mes e Ano

        // POST: DisponibilizarMedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisponibilizarMedicamentoModel disponibilizarMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var disponibilizacao = _mapper.Map<Medicamentodisponivel>(disponibilizarMedicamentoModel);
                _disponibilizarMedicamentoService.Inserir(disponibilizacao);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: DisponibilizarMedicamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Medicamentodisponivel> listaMedicamentosDisponiveis = _disponibilizarMedicamentoService.ObterTodos();
            IEnumerable<Medicamento> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<Farmacia> listaFarmacias = _farmaciaService.ObterTodos();
            Medicamentodisponivel disponibilizacao = _disponibilizarMedicamentoService.Obter(id);

            ViewBag.IdDisponibilizacaoMedicamento = new SelectList(listaMedicamentosDisponiveis, "IdDisponibilizacaoMedicamento", "Nome", disponibilizacao.IdMedicamentoNavigation);
            ViewBag.IdMedicamento = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", disponibilizacao.IdMedicamentoNavigation);
            ViewBag.IdFarmacia = new SelectList(listaFarmacias, "IdFarmacia", "Nome", disponibilizacao.IdFarmaciaNavigation);


            DisponibilizarMedicamentoModel disponibilizacaoModel = _mapper.Map<DisponibilizarMedicamentoModel>(disponibilizacao);
            return View(disponibilizacaoModel);
        }

        // POST: DisponibilizarMedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DisponibilizarMedicamentoModel disponibilizarMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var disponibilizacao = _mapper.Map<Medicamentodisponivel>(disponibilizarMedicamentoModel);
                _disponibilizarMedicamentoService.Editar(disponibilizacao);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: DisponibilizarMedicamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Medicamentodisponivel disponibilizacao = _disponibilizarMedicamentoService.Obter(id);
            DisponibilizarMedicamentoModel disponibilizacaoModel = _mapper.Map<DisponibilizarMedicamentoModel>(disponibilizacao);
            return View(disponibilizacaoModel);
        }

        // POST: DisponibilizarMedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _disponibilizarMedicamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
