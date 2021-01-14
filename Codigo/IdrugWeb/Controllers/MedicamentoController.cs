using AutoMapper;
using Core;
using Core.Service;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Controllers
{
    public class MedicamentoController : Controller
    {
        IMedicamentoService _medicamentoService;
        IMapper _mapper;

        public MedicamentoController(IMedicamentoService medicamentoService, IMapper mapper)
        {
            _medicamentoService = medicamentoService;
            _mapper = mapper;
        }


        // GET: MedicamentoController
        public ActionResult Index()
        {
            var listaMedicamentos = _medicamentoService.ObterTodos();
            var listaMedicamentosModel = _mapper.Map<List<MedicamentoModel>>(listaMedicamentos);
            return View(listaMedicamentosModel);
        }


        // GET: MedicamentoController/Details/5
        public ActionResult Details(int id)
        {
            Medicamento medicamento = _medicamentoService.Obter(id);
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            return View(medicamentoModel);
        }
       

        // GET: MedicamentoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: MedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(MedicamentoModel medicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoModel);
                _medicamentoService.Inserir(medicamento);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: MedicamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Medicamento medicamento = _medicamentoService.Obter(id);
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            return View(medicamentoModel);
        }


        // POST: MedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, MedicamentoModel medicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoModel);
                _medicamentoService.Editar(medicamento);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: MedicamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Medicamento medicamento = _medicamentoService.Obter(id);
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            return View(medicamentoModel);
        }


        // POST: MedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, MedicamentoModel medicamentoModel)
        {
            _medicamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
