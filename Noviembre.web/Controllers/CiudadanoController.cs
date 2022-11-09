using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class CiudadanoController : Controller
    {
        // GET: Ciudadano
        public ActionResult Index()
        {
            List<Ciudadano> ciudadanos = Ciudadano.GetAllCiudadanos();
            return View(ciudadanos);
        }
    }
}