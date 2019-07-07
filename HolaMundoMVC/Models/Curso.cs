using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required]
        [StringLength(5)]
        public override string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Display(Name="Address",Prompt="Direccion de Correspondencia")]
        [Required]
        [MinLength(10)]
        public string Direccion { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }
    }
}