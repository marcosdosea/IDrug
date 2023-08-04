using AutoMapper;
using Core;
using Core.Service;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Security.Policy;
using System.Text.Json;

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

        [HttpPost]
        public ActionResult RealizarSolicitacao(string medicamentoDisponivel)
        {
            try
            {
                var disponibilizarMedicamento = JsonSerializer.Deserialize<DisponibilizarMedicamentoModel>(medicamentoDisponivel);
                Solicitacaomedicamento solicitacao = new Solicitacaomedicamento();
                solicitacao.IdDisponibilizacaoMedicamento = disponibilizarMedicamento.IdDisponibilizacaoMedicamento;

                //DEFININDO ESTATICAMENTE PADRÕES DA SOLICITAÇÃO DE PRODUTO UNICO
                solicitacao.IdUsuario = 1; //ID DE USUARIO MOCKADO ENQUANTO O LOGIN NÃO ESTÁ FUNCIONANDO
                solicitacao.Cpf = "12345678909";
                solicitacao.DataSolicitacao = DateTime.Now;
                solicitacao.QuantidadeSolicitada = 1;
                solicitacao.StatusSolicitacaoMedicamento = "EM ANDAMENTO";
                solicitacao.PrazoEntrega = solicitacao.DataSolicitacao.AddDays(3); // 3 dias depois da data de solicitacao;
                solicitacao.DataEntrega = DateTime.Now;
                solicitacao.QuantidadeEntregue = 1;

                _solicitacaoMedicamentoService.Inserir(solicitacao);

            }
            catch (Exception ex)
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAErro ao desserializar JSON: " + ex.Message);
            }

            

            return RedirectToAction("Index", "Home");
        }

        // GET: SolicitacaoMedicamentoController
        public ActionResult Index()
        {
            List<SolicitacaoMedicamentoModel> lista_medicamentos_solicitados = new List<SolicitacaoMedicamentoModel>();

            var listaSolicitacoes = _solicitacaoMedicamentoService.ObterTodos();
            var listaSolicitacoesOrganizada = _mapper.Map<List<SolicitacaoMedicamentoModel>>(listaSolicitacoes);

            lista_medicamentos_solicitados.AddRange(listaSolicitacoesOrganizada);

            return View(listaSolicitacoesOrganizada);
        }

        public ActionResult IndexUsuario()
        {
            List<SolicitacaoMedicamentoModel> lista_medicamentos_solicitados = new List<SolicitacaoMedicamentoModel>();

            var listaSolicitacoes = _solicitacaoMedicamentoService.ObterPorCPF("12345678909");
            var listaSolicitacoesOrganizada = _mapper.Map<List<SolicitacaoMedicamentoModel>>(listaSolicitacoes);

            lista_medicamentos_solicitados.AddRange(listaSolicitacoesOrganizada);

            return View(lista_medicamentos_solicitados);
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
                solicitacao.Cpf = "12345678909";
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
