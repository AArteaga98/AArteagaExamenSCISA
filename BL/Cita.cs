using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cita
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.CitaGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Cita cita = new ML.Cita();
                            //ML.Cita cita1 = new ML.Cita();
                            cita.Id_Cita = row.Id_Cita;
                            cita.FechaCita = row.FechaCita;
                            cita.HoraCita = row.HoraCita;

                            cita.Doctor = new ML.Doctor();
                            cita.Doctor.Id_Doctor = row.Id_Doctor;
                            cita.Doctor.Nombre = row.Medico;
                            cita.Doctor.ApellidoPaterno = row.ApellidoPaterno;

                            cita.Paciente = new ML.Paciente();
                            cita.Paciente.Id_Paciente = row.Id_Paciente;
                            cita.Paciente.Nombre = row.Paciente;
                            cita.Paciente.ApellidoMaterno = row.ApellidoMaterno;


                            result.Objects.Add(cita);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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

        public static ML.Result GetById(int Id_Cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.CitaGetById(Id_Cita).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Cita cita = new ML.Cita();
                        cita.Id_Cita = query.Id_Cita;
                        cita.FechaCita = query.FechaCita;
                        cita.HoraCita = query.HoraCita;

                        cita.Doctor = new ML.Doctor();
                        cita.Doctor.Id_Doctor = query.Id_Doctor;
                        cita.Doctor.Nombre = query.Medico;
                        cita.Doctor.ApellidoPaterno = query.ApellidoPaterno;

                        cita.Paciente = new ML.Paciente();
                        cita.Paciente.Id_Paciente = query.Id_Paciente;
                        cita.Paciente.Nombre = query.Paciente;
                        cita.Paciente.ApellidoMaterno = query.ApellidoMaterno;

                        result.Object = cita;
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

        public static ML.Result Add(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    int query = context.CitaAdd(cita.FechaCita, cita.HoraCita, cita.Doctor.Id_Doctor, cita.Paciente.Id_Paciente);

                    if (query > 0)
                    {
                        result.Message = "Cita Registrada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al agregar cita" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.CitaUpdate(cita.Id_Cita, cita.FechaCita, cita.HoraCita, cita.Doctor.Id_Doctor, cita.Paciente.Id_Paciente);

                    if (query > 0)
                    {
                        result.Message = "Cita Modificada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar la cita" + result.Ex;

            }
            return result;
        }

        public static ML.Result Delete(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    int query = context.DoctorDelete(cita.Id_Cita);

                    if (query > 0)
                    {
                        result.Message = "Cita Eliminada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la cita" + result.Ex;

            }
            return result;
        }

    }
}
