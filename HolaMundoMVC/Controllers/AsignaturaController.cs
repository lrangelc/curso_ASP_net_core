using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;

namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura{Nombre="Programacion"};
            // escuela.UniqueId = Guid.NewGuid().ToString();
            
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = System.DateTime.Now;

            return View(asignatura);
        }
    }
}
