using AutoMapper;
using Core.Service;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;

namespace IdrugWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IDisponibilizarMedicamentoService _disponibilizarMedicamentoService;
        IMedicamentoService _medicamentoService;
        IMapper _mapper;

        public HomeController(IDisponibilizarMedicamentoService DisponibilizarMedicamentoService,IMedicamentoService medicamentoService, ILogger<HomeController> logger, IMapper mapper)
        {
            _disponibilizarMedicamentoService = DisponibilizarMedicamentoService;
            _medicamentoService = medicamentoService;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var DisponibilizarMedicamento = _disponibilizarMedicamentoService.ObterTodos();
            var listaMedicamentosDisponiveis = _mapper.Map<List<DisponibilizarMedicamentoModel>>(DisponibilizarMedicamento);
            var Medicamentos = _medicamentoService.ObterTodos();

            var disponibilizarMedicamento = new DisponibilizarMedicamentoViewModel(listaMedicamentosDisponiveis, Medicamentos);

            return View(disponibilizarMedicamento);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Painel()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
