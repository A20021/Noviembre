using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            List<Cita> citas = Cita.GetAllCitas();
            return View(citas);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(DateTime fecha, int idModulo, int idCiudadano, int idTramite, int idDocumentoNacionalidad, int idComprobanteDomicilio)
        {
            Cita.Guardar(fecha, idModulo, idCiudadano, idTramite, idDocumentoNacionalidad, idComprobanteDomicilio);
            return RedirectToAction("Index");
        }

    }
}