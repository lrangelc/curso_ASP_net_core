using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System;
using System.Linq;

namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;

        public IActionResult Index()
        { 
            ViewBag.CosaDinamica = "La Monja";

            var escuela = _context.Escuelas.FirstOrDefault();

            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}