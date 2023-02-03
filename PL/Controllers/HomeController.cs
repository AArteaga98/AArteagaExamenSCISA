using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ML.Result result = BL.Doctor.GetAll();
            ML.Result resultP = BL.Paciente.GetAll();
            ML.Result resultH = BL.Cita.GetAll();
            ML.Hospital hospital= new ML.Hospital();
            hospital.Doctor = new ML.Doctor();
            hospital.Paciente = new ML.Paciente();
            hospital.Cita = new ML.Cita();

            if (result.Correct)
            {
                hospital.Doctor.Doctores = result.Objects;
                hospital.Paciente.Pacientes = resultP.Objects;
                hospital.Cita.Citas = resultH.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(hospital);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}