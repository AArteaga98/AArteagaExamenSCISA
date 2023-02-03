using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result= BL.Paciente.GetAll();
            ML.Paciente paciente = new ML.Paciente();
            if (result.Correct)
            {
                paciente.Pacientes = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error en la consulta";
            }
            return View(paciente);
        }

        [HttpGet]
        public ActionResult Form(int? Id_Paciente)
        {
            ML.Paciente paciente =new ML.Paciente();
            if (Id_Paciente == null)
            {
                return View(paciente);

            }
            else
            {
                //GetById
                ML.Result result = BL.Paciente.GetById(Id_Paciente.Value);
                if (result.Correct)
                {
                    paciente = (ML.Paciente)result.Object;
                    return View(paciente);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar usuario";
                }
                return View(paciente);

            }
        }



        [HttpPost]
        //Agregar
        public ActionResult Form(ML.Paciente paciente)
        {
            if (paciente.Id_Paciente==0)
            {
                ML.Result result = BL.Paciente.Add(paciente);

                if (result.Correct)
                {
                    ViewBag.Message= result.Message;
                }
                else
                {
                    ViewBag.Message="Error" + result.Message;
                }
            }
            else
            {
                ML.Result result = BL.Paciente.Update(paciente);
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

        public ActionResult Delete(ML.Paciente paciente)
        {
            ML.Result result = BL.Paciente.Delete(paciente);
            if (result.Correct)
            {
                ViewBag.Message=result.Message;
            }
            else
            {
                ViewBag.Message="Error" + result.Message;
            }
            return PartialView("Modal");
        }

    }
}
