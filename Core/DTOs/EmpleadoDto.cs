using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class EmpleadoDto
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public decimal cedula { get; set; }
        public bool estado { get; set; }
        public DateTime horaEntrada { get; set; }
        public DateTime horaSalida { get; set; }
        public int idTipoEmpleado { get; set; }
    }
}
