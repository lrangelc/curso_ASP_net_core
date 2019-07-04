using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace HolaMundoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;

        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ViewBag.CosaDinamica = "La Monja";
                var alumno = _context.Alumnos.FirstOrDefault();

                return View(alumno);
            }
            else
            {
                var alumno = from alm in _context.Alumnos
                                 where alm.Id == id
                                 select alm;
                return View(alumno.SingleOrDefault());
            }
        }

        public IActionResult MultiAlumno()
        {
            return View(_context.Alumnos);
        }

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}