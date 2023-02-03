using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Especialidad
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Especialidad especialidad= new ML.Especialidad();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query  = context.EspecialidadGetAll().ToList();
                    if (query!= null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            especialidad.Id_Especialidad = obj.Id_Especialidad;
                            especialidad.Descripcion= obj.Descripcion;

                            result.Objects.Add(obj);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message= ex.Message;
                
            }

            return result;
        }
    }
}
