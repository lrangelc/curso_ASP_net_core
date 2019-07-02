using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;

        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La Monja";

            var alumno = _context.Alumnos.FirstOrDefault();

            return View(alumno);
        }

        public IActionResult MultiAlumno()
        {
            var listaAlumnos = _context.Alumnos.ToList();

            return View(listaAlumnos);
        }

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}