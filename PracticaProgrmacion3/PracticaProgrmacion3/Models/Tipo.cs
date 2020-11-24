using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaProgrmacion3.Models
{
    public class Tipo
    {
        private int idtipo;
        private string nombre;
        private double precio;

        public int Idtipo { get => idtipo; set => idtipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}