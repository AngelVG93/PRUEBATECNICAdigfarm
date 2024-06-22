using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegistroEntradaDto
    {
        public int idRegistroEntrada { get; set; }
        public int idTipoNovedad { get; set; }
        public int idEmpleado { get; set; }
        public DateTime? horaEntrada { get; set; }
        public DateTime? horaSalida { get; set; }
        public DateTime fechaNovedad { get; set; }
        public decimal horas { get; set; }
        public string descripcion { get; set; }
    }
}
