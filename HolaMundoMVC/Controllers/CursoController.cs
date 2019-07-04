using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HolaMundoMVC.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

        [Route("Curso/")]
        [Route("Curso/{id}")]
        [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ViewBag.CosaDinamica = "La Monja";
                var curso = _context.Cursos.FirstOrDefault();

                return View(curso);
            }
            else
            {
                var curso = from cur in _context.Cursos
                            where cur.Id == id
                            select cur;
                return View(curso.SingleOrDefault());
            }
        }

        public IActionResult MultiCurso()
        {
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;

                _context.Cursos.Add(curso);
                _context.SaveChanges();

                ViewBag.Mensaje_Create = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }


        }
    }
}