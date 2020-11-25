using PracticaProgrmacion3.GestorDatos;
using PracticaProgrmacion3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaProgrmacion3.Controllers
{
    public class TipoController : Controller
    {
        // GET: Tipo
        public ActionResult AltaTipo()
        {
            Tipo tipo = new Tipo();
            return View(tipo);
        }
        [HttpPost]
        public ActionResult AltaTipo(Tipo t)
        {
            GestorBD gestor = new GestorBD();
            gestor.cargarTipo(t);

            return View(t);
        }
    }
}