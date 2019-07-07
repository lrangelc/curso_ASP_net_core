using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
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

        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ViewBag.CosaDinamica = "La Monja";
                var alumno = _context.Alumnos.FirstOrDefault();

                alumno.Curso = Obtener_Curso(alumno.CursoId);

                return View(alumno);
            }
            else
            {
                var alumnos = from alm in _context.Alumnos
                              where alm.Id == id
                              select alm;

                var alumno = alumnos.SingleOrDefault();

                alumno.Curso = Obtener_Curso(alumno.CursoId);

                return View(alumno);
            }
        }

        public IActionResult MultiAlumno()
        {
            return View(_context.Alumnos);
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

            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                ViewBag.Mensaje_CreateUpdate = "Alumno Creado";

                alumno.Curso = Obtener_Curso(alumno.CursoId);

                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        public IActionResult Update(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View("MultiAlumno");
            }
            else
            {
                var alumno = from alm in _context.Alumnos
                                 where alm.Id == id
                                 select alm;

                ViewBag.Fecha = DateTime.Now;

                var content = from p in _context.Cursos
                              select new { p.Id, p.Nombre };

                ViewBag.Cursos = content
                    .Select(c => new SelectListItem
                    {
                        Text = c.Nombre,
                        Value = c.Id.ToString()
                    }).ToList();

                return View(alumno.SingleOrDefault());
            }
        }

        [HttpPost]
        public IActionResult Update(Alumno alumno_act)
        {
            if (ModelState.IsValid)
            {
                var alumno_ant = from asg in _context.Alumnos
                                     where asg.Id == alumno_act.Id
                                     select asg;

                var alumno = alumno_ant.SingleOrDefault();
                alumno.Nombre = alumno_act.Nombre;
                alumno.CursoId = alumno_act.CursoId;

                _context.Alumnos.Update(alumno);
                _context.SaveChanges();

                alumno.Curso = Obtener_Curso(alumno.CursoId);

                ViewBag.Mensaje_CreateUpdate = "Alumno Actualizado";
                return View("Index", alumno);
            }
            else
            {
                return View(alumno_act);
            }
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View("MultiAlumno");
            }
            else
            {
                var alumno = from alm in _context.Alumnos
                                 where alm.Id == id
                                 select alm;

                _context.Alumnos.Remove(alumno.FirstOrDefault());
                _context.SaveChanges();

                return RedirectToAction("MultiAlumno");
            }
        }
    }
}