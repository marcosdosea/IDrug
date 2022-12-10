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
    public class CategoriaMedicamentoController : Controller
    {
        ICategoriaMedicamentoService _categoriaMedicamentoService;
        IMapper _mapper;

        public CategoriaMedicamentoController(ICategoriaMedicamentoService categoriaMedicamentoService, IMapper mapper)
        {
            _categoriaMedicamentoService = categoriaMedicamentoService;
            _mapper = mapper;
        }


        // GET: CategoriaMedicamentoController
        public ActionResult Index()
        {
            var listaCategoriaMedicamento = _categoriaMedicamentoService.ObterTodos();
            var listaCategoriaMedicamentoModel = _mapper.Map<List<CategoriaMedicamentoModel>>(listaCategoriaMedicamento);
            return View(listaCategoriaMedicamentoModel);
        }


        // GET: CategoriaMedicamentoController/Details/5
        public ActionResult Details(int id)
        {
            Categoriamedicamento categoriaMedicamento = _categoriaMedicamentoService.Obter(id);
            CategoriaMedicamentoModel categoriaMedicamentoModel = _mapper.Map<CategoriaMedicamentoModel>(categoriaMedicamento);
            return View(categoriaMedicamentoModel);
        }


        // GET: CategoriaMedicamentoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: CategoriaMedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(CategoriaMedicamentoModel categoriaMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaMedicamento = _mapper.Map<Categoriamedicamento>(categoriaMedicamentoModel);
                _categoriaMedicamentoService.Inserir(categoriaMedicamento);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: CategoriaMedicamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Categoriamedicamento categoriaMedicamento = _categoriaMedicamentoService.Obter(id);
            CategoriaMedicamentoModel categoriaMedicamentoModel = _mapper.Map<CategoriaMedicamentoModel>(categoriaMedicamento);
            return View(categoriaMedicamentoModel);
        }


        // POST: CategoriaMedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, CategoriaMedicamentoModel categoriaMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaMedicamento = _mapper.Map<Categoriamedicamento>(categoriaMedicamentoModel);
                _categoriaMedicamentoService.Editar(categoriaMedicamento);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: CategoriaMedicamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Categoriamedicamento categoriaMedicamento = _categoriaMedicamentoService.Obter(id);
            CategoriaMedicamentoModel categoriaMedicamentoModel = _mapper.Map<CategoriaMedicamentoModel>(categoriaMedicamento);
            return View(categoriaMedicamentoModel);
        }


        // POST: CategoriaMedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, CategoriaMedicamentoModel categoriaMedicamentoModel)
        {
            _categoriaMedicamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
