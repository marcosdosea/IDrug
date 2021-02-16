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
        // TODO: realizar cálculos nos atributos Quantidade Reservada, Quantidade Entregue e Quantidade Disponível 

        // POST: DisponibilizarMedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisponibilizarMedicamentoModel disponibilizarMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var disponibilizacao = _mapper.Map<Medicamentodisponivel>(disponibilizarMedicamentoModel);

                var mesValidade = disponibilizacao.DataVencimento.Month;

                if (mesValidade == 01)
                {
                    disponibilizacao.ValidadeMes = "Janeiro";
                }
                else if (mesValidade == 02)
                {
                    disponibilizacao.ValidadeMes = "Fevereiro";
                }
                else if (mesValidade == 03)
                {
                    disponibilizacao.ValidadeMes = "Março";
                }
                else if (mesValidade == 04)
                {
                    disponibilizacao.ValidadeMes = "Abril";
                }
                else if (mesValidade == 05)
                {
                    disponibilizacao.ValidadeMes = "Maio";
                }
                else if (mesValidade == 06)
                {
                    disponibilizacao.ValidadeMes = "Junho";
                }
                else if (mesValidade == 07)
                {
                    disponibilizacao.ValidadeMes = "Julho";
                }
                else if (mesValidade == 08)
                {
                    disponibilizacao.ValidadeMes = "Agosto";
                }
                else if (mesValidade == 09)
                {
                    disponibilizacao.ValidadeMes = "Setembro";
                }
                else if (mesValidade == 10)
                {
                    disponibilizacao.ValidadeMes = "Outubro";
                }
                else if (mesValidade == 11)
                {
                    disponibilizacao.ValidadeMes = "Novembro";
                }
                else if (mesValidade == 12)
                {
                    disponibilizacao.ValidadeMes = "Dezembro";
                }

                var anoValidade = disponibilizacao.DataVencimento.Year;
                disponibilizacao.ValidadeAno = anoValidade;

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
