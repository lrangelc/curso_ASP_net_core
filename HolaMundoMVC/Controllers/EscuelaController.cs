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
            // var escuela = new Escuela();

            // escuela.Nombre = "Platzi School";
            // escuela.AñoDeCreación = 2005;
            // escuela.TipoEscuela = TiposEscuela.Secundaria;
            // escuela.Dirección = "5ta Calle";
            // escuela.Ciudad = "Tecpan Guatemala";
            // escuela.Pais = "Guatemala";

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