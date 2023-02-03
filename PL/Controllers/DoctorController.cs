using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Doctor.GetAll();
            ML.Doctor doctor= new ML.Doctor();
            if (result.Correct)
            {
              
                doctor.Doctores = result.Objects;
               
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                
            }
            return View(doctor);
        }

        [HttpGet]
        public ActionResult Form(int? Id_Doctor)
        {


            ML.Doctor doctor = new ML.Doctor();

            doctor.Especialidad = new ML.Especialidad();

            ML.Result resultEspecialidad= BL.Especialidad.GetAll();


            if (Id_Doctor == null)
            {

                doctor.Especialidad.Especialidades = resultEspecialidad.Objects;
                return View(doctor);

            }
            else
            {
                //GetById
                ML.Result result = BL.Doctor.GetById(Id_Doctor.Value);

                if (result.Correct)
                {
                    doctor = (ML.Doctor)result.Object;
                    doctor.Especialidad.Especialidades = resultEspecialidad.Objects;

                    return View(doctor);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el Doctor seleccionado";
                }
                return View(doctor);
            }
        }

        [HttpPost]
        //AGREGAR
        public ActionResult Form(ML.Doctor doctor)
        {
            if (doctor.Id_Doctor==0)
            {
                ML.Result result = BL.Doctor.Add(doctor);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Mesage= "Error" + result.Message;
                }

            }
            else
            {
                ML.Result result = BL.Doctor.Update(doctor);

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

        public ActionResult Delete(ML.Doctor doctor)
        {
            ML.Result result = BL.Doctor.Delete(doctor);
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
