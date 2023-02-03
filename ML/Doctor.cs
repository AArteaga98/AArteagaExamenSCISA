using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Doctor
    {
        public int Id_Doctor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string Fotografia { get; set; }
        public string Cedula { get; set; }
        public List<object> Doctores { get; set; }
        public ML.Especialidad Especialidad { get; set;}
    }
}
