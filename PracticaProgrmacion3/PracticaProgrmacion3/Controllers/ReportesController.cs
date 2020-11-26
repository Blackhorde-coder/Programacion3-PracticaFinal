using PracticaProgrmacion3.GestorDatos;
using PracticaProgrmacion3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaProgrmacion3.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Reporte()
        {
            GestorBD gestor = new GestorBD();
            List<DTOreporte> lista = new List<DTOreporte>();
            lista = gestor.reporte();
            return View(lista);
        }
    }
}