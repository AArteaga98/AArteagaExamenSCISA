using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Cita.GetAll();
            ML.Cita cita = new ML.Cita();
            if (result.Correct)
            {

                cita.Citas = result.Objects;

            }
            else
            {
                ViewBag.Message = "Ocurrio un error";

            }
            return View(cita);
        }

        [HttpGet]
        public ActionResult Form(int? Id_Cita)
        {


            ML.Cita cita = new ML.Cita();

            cita.Doctor = new ML.Doctor();
            cita.Paciente = new ML.Paciente();

            ML.Result resultDoctor = BL.Doctor.GetAll();
            ML.Result resultPaciente = BL.Paciente.GetAll();


            if (Id_Cita == null)
            {

                cita.Doctor.Doctores = resultDoctor.Objects;
                cita.Paciente.Pacientes = resultPaciente.Objects;
                return View(cita);

            }
            else
            {
                //GetById
                ML.Result result = BL.Cita.GetById(Id_Cita.Value);

                if (result.Correct)
                {
                    cita = (ML.Cita)result.Object;
                    cita.Doctor.Doctores = resultDoctor.Objects;
                    cita.Paciente.Pacientes = resultPaciente.Objects;

                    return View(cita);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el Doctor seleccionado";
                }
                return View(cita);
            }
        }

        [HttpPost]
        //AGREGAR
        public ActionResult Form(ML.Cita cita)
        {
            if (cita.Id_Cita == 0)
            {
                ML.Result result = BL.Cita.Add(cita);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Mesage = "Error" + result.Message;
                }

            }
            else
            {
                ML.Result result = BL.Cita.Update(cita);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error" + result.Message;
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(ML.Cita cita)
        {
            ML.Result result = BL.Cita.Delete(cita);
            if (result.Correct)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "ERROR: " + result.Message;
            }
            return PartialView("Modal");
        }


    }
}