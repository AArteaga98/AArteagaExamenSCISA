using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Hospital
    {
        public ML.Paciente Paciente { get; set; }
        public ML.Doctor Doctor { get; set; }
        public ML.Cita Cita { get; set; }
    }
}
