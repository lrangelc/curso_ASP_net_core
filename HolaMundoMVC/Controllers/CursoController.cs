using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace HolaMundoMVC.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;

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
            return View(_context.Cursos);
        }

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}