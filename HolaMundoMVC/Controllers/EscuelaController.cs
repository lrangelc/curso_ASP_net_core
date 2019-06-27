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
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Year_Fundacion = 2005;

            return View(escuela);
        }
    }
}
