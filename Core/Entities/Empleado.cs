using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Empleado
    {
        [Key]
        public int idEmpleado { get; set; } 
        public string nombre { get;set; }
        public decimal cedula { get; set; }
        public bool estado { get; set; }
        public DateTime horaEntrada { get; set;}
        public DateTime horaSalida { get; set; }
        public int idTipoEmpleado { get; set; }
        public virtual TipoEmpledo? IdTipoEmpledoNavigation { get; set; } 
        public virtual ICollection<RegistroEmpleado> ? RegistroEntradas { get; set; }
    }
}
