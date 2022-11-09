using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class ModuloController : Controller
    {
        // GET: Modulo
        public ActionResult Index()
        {
            List<Modulo> modulos = Modulo.GetAllModulos();
            return View(modulos);
        }
    }
}