using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class ComprobanteDomicilioController : Controller
    {
        // GET: ComprobanteDomicilio
        public ActionResult Index()
        {
            List<ComprobanteDomicilio> comprobantes = ComprobanteDomicilio.GetAllComprobantes();
            return View(comprobantes);
        }
    }
}