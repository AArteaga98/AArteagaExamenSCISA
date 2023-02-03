using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            result = BL.Login.Log(usuario);

            if (result.Correct)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Contraseña y usuario incorrecto";
                return PartialView("Modal");
            }
        }
    }
}