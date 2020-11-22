using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaProgrmacion3.Models
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private int edad;
        private int documento;

        public Persona(string nombre, string apellido, int edad, int documento)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Documento = documento;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Documento { get => documento; set => documento = value; }
    }
}