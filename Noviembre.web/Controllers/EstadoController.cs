﻿using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index(){
            List<Estado> estados = Estado.GetAll();
            return View();
        }
    }
}