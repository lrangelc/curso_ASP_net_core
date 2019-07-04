using System;

namespace HolaMundoMVC.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }

        //al asignar la opcion: virtual
        //podemos hacer un override en la clase hija
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}