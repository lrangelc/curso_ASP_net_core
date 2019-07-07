using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }


        private Curso Obtener_Curso(string CursoId)
        {
            var curso = from cur in _context.Cursos
                        where cur.Id == CursoId
                        select cur;

            return curso.FirstOrDefault();
        }

        // [Route("Asignatura")]
        // //Para que acepte que no se envie un parametro
        // [Route("Asignatura/Index")]
        // //Para que acepte que el id en la ruta pueda llamarse asignaturaId
        // [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ViewBag.CosaDinamica = "La Monja";

                var asignatura = _context.Asignaturas.FirstOrDefault();

                asignatura.Curso = Obtener_Curso(asignatura.CursoId);

                return View(asignatura);
            }
            else
            {
                var asignaturas = from asg in _context.Asignaturas
                                  where asg.Id == id
                                  select asg;

                var asignatura = asignaturas.SingleOrDefault();

                asignatura.Curso = Obtener_Curso(asignatura.CursoId);

                return View(asignatura);
            }
        }

        public IActionResult MultiAsignatura()
        {
            return View(_context.Asignaturas);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;


            var content = from p in _context.Cursos
                          select new { p.Id, p.Nombre };

            ViewBag.Cursos = content
                .Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }).ToList();


            // var cursos = (from curs in _context.Cursos select curs).ToList();
            // var lista = new List<SelectListItem>();
            // foreach (Curso curs in cursos)
            // {
            //     lista.Add(new SelectListItem { Text = curs.Nombre, Value = curs.Id });
            // }
            // ViewBag.Cursos = lista;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();

                ViewBag.Mensaje_CreateUpdate = "Asignatura Creada";

                asignatura.Curso = Obtener_Curso(asignatura.CursoId);

                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }


        public IActionResult Update(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View("MultiAsignatura");
            }
            else
            {
                var asignatura = from asg in _context.Asignaturas
                                 where asg.Id == id
                                 select asg;

                ViewBag.Fecha = DateTime.Now;


                var content = from p in _context.Cursos
                              select new { p.Id, p.Nombre };

                ViewBag.Cursos = content
                    .Select(c => new SelectListItem
                    {
                        Text = c.Nombre,
                        Value = c.Id.ToString()
                    }).ToList();

                return View(asignatura.SingleOrDefault());
            }
        }


        [HttpPost]
        public IActionResult Update(Asignatura asignatura_act)
        {
            if (ModelState.IsValid)
            {
                var asignatura_ant = from asg in _context.Asignaturas
                                     where asg.Id == asignatura_act.Id
                                     select asg;

                var asignatura = asignatura_ant.SingleOrDefault();
                asignatura.Nombre = asignatura_act.Nombre;
                asignatura.CursoId = asignatura_act.CursoId;

                _context.Asignaturas.Update(asignatura);
                _context.SaveChanges();

                asignatura.Curso = Obtener_Curso(asignatura.CursoId);

                ViewBag.Mensaje_CreateUpdate = "Asignatura Actualizada";
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura_act);
            }
        }
    }
}