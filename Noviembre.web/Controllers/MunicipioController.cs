using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        public ActionResult Index()
        {
            List<Municipio> municipios = Municipio.GellAllMunicipios();
            return View(municipios);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String nombre, int idEstado)
        {
            Municipio.Guardar(nombre, idEstado);
            return RedirectToAction("Index");
        }
    }
}