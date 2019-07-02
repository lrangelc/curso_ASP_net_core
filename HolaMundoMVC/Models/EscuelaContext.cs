using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoMVC.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.Nombre = "Platzi School";
            escuela.AñoDeCreación = 2005;
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "5ta Calle";
            escuela.Ciudad = "Tecpan Guatemala";
            escuela.Pais = "Guatemala";
            modelBuilder.Entity<Escuela>().HasData(escuela);

            var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"},
                            new Asignatura{Nombre="Programacion"}
                };
            modelBuilder.Entity<Asignatura>().HasData(listaAsignaturas);

            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar(5).ToArray());
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
    }
}