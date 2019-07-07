using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { get; set; }
        
        public List<Evaluación> Evaluaciones { get; set; }

        public string CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}