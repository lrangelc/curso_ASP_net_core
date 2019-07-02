using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;

        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La Monja";
            var asignatura = _context.Asignaturas.FirstOrDefault();

            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {
            return View(_context.Asignaturas);
        }

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}