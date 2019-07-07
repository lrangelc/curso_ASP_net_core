using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    public class Escuela:ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { get; set; }

        public int YearDeCreacion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int year) => (Nombre, YearDeCreacion) = (nombre, year);

        public Escuela()
        {

        }

        public Escuela(string nombre, int año, 
                       TiposEscuela tipo, 
                       string pais = "", string ciudad = "") : base()
        {
            (Nombre, YearDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}