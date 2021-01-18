using AutoMapper;
using Core;
using Core.Services;
using IdrugWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdrugWeb.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioService _usuarioService;
        IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            Usuario usuario = _usuarioService.Obter(id);
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            return View(usuarioModel);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = _mapper.Map<Usuario>(usuarioModel);
                int v = _usuarioService.Inserir(usuario);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = _usuarioService.Obter(id);
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            return View(usuarioModel);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = _mapper.Map<Usuario>(usuarioModel);
                _usuarioService.Editar(usuario);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = _usuarioService.Obter(id);
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            return View(usuarioModel);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioModel usuarioModel)
        {
            _usuarioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
