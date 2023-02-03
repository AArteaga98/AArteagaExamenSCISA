using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {
        public static ML.Result Log(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AArteagaExamenSCISAEntities context = new DL.AArteagaExamenSCISAEntities())
                {
                    var query = context.LoginU(usuario.Username,usuario.Password).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        //ML.Usuario usuario = new ML.Usuario();

                        
                        usuario.Username = query.Username;
                        usuario.Password = query.Password;


                        result.Object = usuario;
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

    }
}
