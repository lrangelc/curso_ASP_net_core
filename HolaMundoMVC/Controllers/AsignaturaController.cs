using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;



        [Route("Asignatura")]
        //Para que acepte que no se envie un parametro
        [Route("Asignatura/Index")]
        //Para que acepte que el id en la ruta pueda llamarse asignaturaId
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ViewBag.CosaDinamica = "La Monja";
                var asignatura = _context.Asignaturas.FirstOrDefault();

                return View(asignatura);
            }
            else
            {
                var asignatura = from asg in _context.Asignaturas
                                 where asg.Id == id
                                 select asg;
                return View(asignatura.SingleOrDefault());
            }
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