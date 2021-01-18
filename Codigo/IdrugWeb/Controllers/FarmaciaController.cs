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
    public class FarmaciaController : Controller
    {
        IFarmaciaService _farmaciaService;
        IMapper _mapper;

        public FarmaciaController(IFarmaciaService farmaciaService, IMapper mapper)
        {
            _farmaciaService = farmaciaService;
            _mapper = mapper;
        }
        // GET: FarmaciaController
        public ActionResult Index()
        {
            var listaFarmacias = _farmaciaService.ObterTodos();
            var listaFarmaciaModel = _mapper.Map<List<FarmaciaModel>>(listaFarmacias);
            return View(listaFarmaciaModel);
        }

        // GET: FarmaciaController/Details/5
        public ActionResult Details(int id)
        {
            Farmacia farmacia = _farmaciaService.Obter(id);
            FarmaciaModel farmaciaModel = _mapper.Map<FarmaciaModel>(farmacia);
            return View(farmaciaModel);
        }

        // GET: FarmaciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmaciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FarmaciaModel farmaciaModel)
        {
            if (ModelState.IsValid)
            {
                var farmacia = _mapper.Map<Farmacia>(farmaciaModel);
                _farmaciaService.Inserir(farmacia);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult CreateSolicitacaoFarmacia()
        {
            return View();
        }

        // POST: FarmaciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSolicitacaoFarmacia(FarmaciaModel farmaciaModel)
        {
            if (ModelState.IsValid)
            {
                var farmacia = _mapper.Map<Farmacia>(farmaciaModel);
                _farmaciaService.Inserir(farmacia);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: FarmaciaController/Edit/5
        public ActionResult Edit(int id)
        {
            Farmacia farmacia = _farmaciaService.Obter(id);
            FarmaciaModel farmaciaModel = _mapper.Map<FarmaciaModel>(farmacia);
            return View(farmaciaModel);
        }

        // POST: FarmaciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FarmaciaModel farmaciaModel)
        {
            if (ModelState.IsValid)
            {
                var farmacia = _mapper.Map<Farmacia>(farmaciaModel);
                _farmaciaService.Editar(farmacia);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: FarmaciaController/Delete/5
        /* public ActionResult Delete(int id)
        {
            Farmacia farmacia = _farmaciaService.Obter(id);
            FarmaciaModel farmaciaModel = _mapper.Map<FarmaciaModel>(farmacia);
            return View(farmaciaModel);
        }*/

    }
}
