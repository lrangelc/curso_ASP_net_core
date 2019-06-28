using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System;

namespace HolaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            // escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.AñoDeCreación = 2005;
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "5ta Calle";
            escuela.Ciudad = "Tecpan Guatemala";
            escuela.Pais = "Guatemala";

            ViewBag.CosaDinamica = "La Monja";

            return View(escuela);
        }
    }
}