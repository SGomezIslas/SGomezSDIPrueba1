using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            Dictionary<string, object> objeto = BL.Usuario.GetAll();
            bool resultado = (bool)objeto["Resultado"];
            if (resultado)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario = (ML.Usuario)objeto["Usuario"];
                return View(usuario);
            }
            else
            {
                string excepcion = (string)objeto["Excepcion"];
                ViewBag.Mensaje = $"Ocurrio un error {excepcion}";
                return View(excepcion);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            if (IdUsuario != null)
            {
                Dictionary<string, object> result = BL.Usuario.GetById(IdUsuario.Value);
                bool resultado = (bool)result["Resultado"];
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            Dictionary<string, object> result = BL.Usuario.Add(usuario);
            bool resultado = (bool)result["Resultado"];
            if (resultado)
            {
                ViewBag.Mensaje = "El Usuario ha sido insertado";
                return PartialView("Modal");
            }
            else
            {           
                string exepcion = (string)result["Exepcion"];
                ViewBag.Mensaje = "El usuario no se pudo registrar " + exepcion;
                return PartialView("Modal");
            }
        }
        public ActionResult Delete(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            Dictionary<string, object> result = BL.Usuario.Delete(IdUsuario.Value);
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {
                ViewBag.Mensaje = "El Usuario ha sido eliminado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Mensaje = "ERROR! El usuario no se elimino "; 
                return PartialView("Modal");
            }
        }
    }
}
