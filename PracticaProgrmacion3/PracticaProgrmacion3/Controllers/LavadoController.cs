using PracticaProgrmacion3.GestorDatos;
using PracticaProgrmacion3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaProgrmacion3.Controllers
{
    public class LavadoController : Controller
    {
        // GET: Lavado
        public ActionResult Alta()
        {
            List<Tipo> lista = new List<Tipo>();
            GestorBD gestor = new GestorBD();
            lista = gestor.ListaTipos();
            informacion info = new informacion();
            info.listado = lista;
            return View( info );
        }
        [HttpPost]
        public ActionResult Alta(informacion lol)
        {
            GestorBD gestor = new GestorBD();
            gestor.cargarLavado(lol.lavado);
            List<DTOlistado> lista = new List<DTOlistado>();
            lista = gestor.listadoLavados();
            return View("Listado",lista);
        }


    }
}