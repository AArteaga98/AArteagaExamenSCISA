using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cita
    {
        public int Id_Cita { get; set; }
       public string FechaCita { get; set; }
       public string HoraCita { get; set; }
        public List<object> Citas { get; set; }
        public ML.Doctor Doctor { get; set; }
        public ML.Paciente Paciente { get; set; }

    }
}
