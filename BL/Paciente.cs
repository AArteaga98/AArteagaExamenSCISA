using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.PacienteGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.Id_Paciente = obj.Id_Paciente;
                            paciente.Nombre=obj.Nombre;
                            paciente.ApellidoPaterno=obj.ApellidoPaterno;
                            paciente.ApellidoMaterno=obj.ApellidoMaterno;
                            paciente.FechaNacimiento=obj.FechaNacimiento;
                            paciente.CURP=obj.CURP;
                            paciente.NSS=obj.NSS;
                            paciente.Sexo = obj.Sexo;
                            paciente.Telefono=obj.Telefono;
                            paciente.Direccion=obj.Direccion;
                            paciente.CodigoPostal=obj.CodigoPostal;
                            paciente.Diagnostico=obj.Diagnostico;

                            paciente.NombreCompleto = paciente.Nombre + " " + paciente.ApellidoMaterno;

                            result.Objects.Add(paciente);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Sin Registros";
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

        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.PacienteAdd(paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.FechaNacimiento, paciente.CURP, paciente.NSS, paciente.Sexo, paciente.Telefono, paciente.Direccion, paciente.CodigoPostal, paciente.Diagnostico);

                    if (query>0)
                    {
                        result.Message = "Paciente registrado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Ex= ex;
                result.Message = ex.Message;
                
            }
            return result;
        }

        public static ML.Result GetById(int Id_Paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.PacienteGetById(Id_Paciente).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.Id_Paciente = query.Id_Paciente;
                        paciente.Nombre = query.Nombre;
                        paciente.ApellidoPaterno = query.ApellidoPaterno;
                        paciente.ApellidoMaterno = query.ApellidoMaterno;
                        paciente.FechaNacimiento = query.FechaNacimiento;
                        paciente.CURP = query.CURP;
                        paciente.NSS = query.NSS;
                        paciente.Sexo = query.Sexo;
                        paciente.Telefono = query.Telefono;
                        paciente.Direccion = query.Direccion;
                        paciente.CodigoPostal = query.CodigoPostal;
                        paciente.Diagnostico = query.Diagnostico;



                        result.Object = paciente;
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

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.PacienteUpdate(paciente.Id_Paciente, paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno, paciente.FechaNacimiento, paciente.CURP, paciente.NSS, paciente.Sexo, paciente.Telefono, paciente.Direccion, paciente.CodigoPostal, paciente.Diagnostico);

                    if (query > 0)
                    {
                        result.Message = "Paciente Modificado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar paciente" + result.Ex;
                
            }
            return result;
        }

        public static ML.Result Delete(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    int query = context.PacienteDelete(paciente.Id_Paciente);

                    if (query > 0)
                    {
                        result.Message = "Paciente Eliminado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar Paciente" + result.Ex;
                throw;
            }
            return result;
        }


    }
}
