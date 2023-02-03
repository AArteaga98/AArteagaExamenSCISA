using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paciente
    {
        public int Id_Paciente { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [DisplayName("Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public string NSS { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Diagnostico { get; set; }

        public List<object> Pacientes { get; set; }
    }
}
