using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Especialidad
    {
        [DisplayName("Especialidad")]
        public int Id_Especialidad { get; set; }
        public string Descripcion { get; set; }
        public List<object> Especialidades { get; set; }
    }
}
