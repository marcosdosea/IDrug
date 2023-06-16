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
        IMedicamentoService _medicamentoService;
        IMapper _mapper;

        public HomeController(IMedicamentoService medicamentoService, ILogger<HomeController> logger, IMapper mapper)
        {
            _medicamentoService = medicamentoService;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var listaMedicamentos = _medicamentoService.ObterTodos();
            var listaMedicamentosModel = _mapper.Map<List<MedicamentoModel>>(listaMedicamentos);
            return View(listaMedicamentosModel);
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
