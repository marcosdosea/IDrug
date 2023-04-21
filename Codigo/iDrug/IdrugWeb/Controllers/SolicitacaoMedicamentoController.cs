using AutoMapper;
using Core;
using Core.Service;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Security.Policy;

namespace IdrugWeb.Controllers
{
    public class SolicitacaoMedicamentoController : Controller
    {

        ISolicitacaoMedicamentoService _solicitacaoMedicamentoService;
        IUsuarioService _usarioService;
        IMapper _mapper;
        ISolicitacaoMedicamentoService _solicitacaoMedicamento;

        public SolicitacaoMedicamentoController(IMapper mapper, ISolicitacaoMedicamentoService solicitacaoMedicamentoService, IUsuarioService usarioService)
        {
            _solicitacaoMedicamentoService = solicitacaoMedicamentoService;
            _usarioService = usarioService;
            _mapper = mapper;
        }


        // GET: SolicitacaoMedicamentoController
        public ActionResult Index()
        {
            var listaSolicitacoes = _solicitacaoMedicamentoService.ObterTodos();
            var listaSolicitacoesModel = _mapper.Map<List<Solicitacaomedicamento>>(listaSolicitacoes);
            return View(listaSolicitacoesModel);
        }

        // GET: SolicitacaoMedicamentoController/Details/5
        public ActionResult Details(int id)
        {
            Solicitacaomedicamento solicitacaomedicamento = _solicitacaoMedicamentoService.Obter(id);
            SolicitacaoMedicamentoModel solicitacaoMedicamentoModel = _mapper.Map<SolicitacaoMedicamentoModel>(solicitacaomedicamento);
            return View(solicitacaoMedicamentoModel);
        }

        // GET: SolicitacaoMedicamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitacaoMedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitacaoMedicamentoModel solicitacaoMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var solicitacao = _mapper.Map<Solicitacaomedicamento>(solicitacaoMedicamentoModel);
                solicitacao.DataSolicitacao = DateTime.Now;
                _solicitacaoMedicamentoService.Inserir(solicitacao);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoMedicamentoController/Edit/5
        public ActionResult Edit(int idSolicitacao)
        {
            Solicitacaomedicamento solicitacao = _solicitacaoMedicamentoService.Obter(idSolicitacao);

            return View(solicitacao);
        }

        // POST: SolicitacaoMedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SolicitacaoMedicamentoModel solicitacaoModel)
        {
            if (ModelState.IsValid)
            {
                var solicitacaoMedicamento = _mapper.Map<Solicitacaomedicamento>(solicitacaoModel);
                _solicitacaoMedicamentoService.Editar(solicitacaoMedicamento);

            }

            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoMedicamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Solicitacaomedicamento solicitacao = _solicitacaoMedicamentoService.Obter(id);
            SolicitacaoMedicamentoModel solicitacaoModel = _mapper.Map<SolicitacaoMedicamentoModel>(solicitacao);
            return View(solicitacaoModel);
        }

        // POST: SolicitacaoMedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SolicitacaoMedicamentoModel solicitacao)
        {
           _solicitacaoMedicamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
