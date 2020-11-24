using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaProgrmacion3.Models
{
    public class Lavado
    {
        private int id;
        private string patente;
        private bool taxi;
        private bool habitual;
        private int idtipo;

        public int Id { get => id; set => id = value; }
        public string Patente { get => patente; set => patente = value; }
        public bool Taxi { get => taxi; set => taxi = value; }
        public bool Habitual { get => habitual; set => habitual = value; }
        public int Idtipo { get => idtipo; set => idtipo = value; }
    }
}