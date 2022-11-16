using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuarios = Usuario.GetAllUsuarios();
            return View(usuarios);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String nombre, String email, String password)
        {
            Usuario.Guardar(nombre, email, password);
            return RedirectToAction("Index");
        }
    }
}