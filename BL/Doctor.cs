using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Doctor
    {
        public static ML.Result GetAll() 
        {

            ML.Result result = new ML.Result();
           
      
          
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.DoctorGetAll().ToList();
                    result.Objects=new List<object>();

                    if (query!=null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Doctor doctor = new ML.Doctor();
                            ML.Doctor doc1 = new ML.Doctor();
                            doctor.Id_Doctor = obj.Id_Doctor;
                            doctor.Nombre = obj.Nombre;
                            doctor.ApellidoPaterno = obj.ApellidoPaterno;
                            doctor.ApellidoMaterno = obj.ApellidoMaterno;
                            doctor.Fotografia = obj.Fotografia;
                            doctor.Cedula = obj.Cedula;

                            doctor.Especialidad= new ML.Especialidad();
                            doctor.Especialidad.Id_Especialidad = (int)obj.Id_Especialidad;
                            doctor.Especialidad.Descripcion = obj.Descripcion;

                            doctor.NombreCompleto = doctor.Nombre + " " + doctor.ApellidoPaterno;

                            result.Objects.Add(doctor); 
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron Registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
               
            }

        
        
            return result;
        }

        public static ML.Result Add(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    int query = context.DoctorAdd(doctor.Nombre, doctor.ApellidoPaterno, doctor.ApellidoMaterno,  doctor.Cedula, doctor.Fotografia, doctor.Especialidad.Id_Especialidad);

                    if (query > 0)
                    {
                        result.Message = "Doctor Registrado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al agregar Doctor" + result.Ex;
               
            }
            return result;
        }

        public static ML.Result GetById(int Id_Doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.DoctorGetById(Id_Doctor).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Doctor doctor = new ML.Doctor();
                        doctor.Id_Doctor = query.Id_Doctor;
                        doctor.Nombre = query.Nombre;
                        doctor.ApellidoPaterno = query.ApellidoPaterno;
                        doctor.ApellidoMaterno = query.ApellidoMaterno;
                        doctor.Fotografia = query.Fotografia ;
                        doctor.Cedula = query.Cedula;
                        doctor.Especialidad = new ML.Especialidad();
                        doctor.Especialidad.Id_Especialidad = (int)query.Id_Especialidad;

                        result.Object = doctor;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al obtener registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
               
            }
            return result;
        }

        public static ML.Result Update(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.DoctorUpdate(doctor.Id_Doctor, doctor.Nombre, doctor.ApellidoPaterno, doctor.ApellidoMaterno,  doctor.Cedula, doctor.Fotografia, doctor.Especialidad.Id_Especialidad);

                    if (query > 0)
                    {
                        result.Message = "Doctor Modificado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar Doctor" + result.Ex;
                
            }
            return result;
        }

        public static ML.Result Delete(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    int query = context.DoctorDelete(doctor.Id_Doctor);

                    if (query > 0)
                    {
                        result.Message = "Doctor Eliminado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar Doctor" + result.Ex;
               
            }
            return result;
        }

    }
}
