using AutoMapper;
using Core;
using Core.Service;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using System.IO;

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
            var listaMedicamento = _medicamentoService.ObterTodos();
            var listaDisponibilizacaoMedicamentosModel = _mapper.Map<List<DisponibilizarMedicamentoModel>>(listaDisponibilizacaoMedicamentos);
            var medicamentoViewModel = new DisponibilizarMedicamentoViewModel(listaDisponibilizacaoMedicamentosModel, listaMedicamento);
            return View(medicamentoViewModel);
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
        public async Task<ActionResult> CreateAsync(DisponibilizarMedicamentoModel disponibilizarMedicamentoModel, IFormFile imagem)
        {
            if (ModelState.IsValid && imagem != null && imagem.Length > 0)
            {
                var medicamentoParaDisponibilizar = _mapper.Map<Medicamentodisponivel>(disponibilizarMedicamentoModel);
                medicamentoParaDisponibilizar.QuantidadeEntregue = 0;
                medicamentoParaDisponibilizar.QuantidadeReservada = 0;
                //Adicionando imagem no model
                using (var memoryStream = new MemoryStream())
                {
                    await imagem.CopyToAsync(memoryStream);
                    medicamentoParaDisponibilizar.Imagem = memoryStream.ToArray();
                }
                _disponibilizarMedicamentoService.Inserir(medicamentoParaDisponibilizar);
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
