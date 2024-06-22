using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class RegistroEntrada
    {
        [Key]
        public int idRegistroEntrada { get; set; } 
        public int? idTipoNovedad { get; set; }
        public int idEmpleado { get; set; } 
        public DateTime? horaEntrada { get; set; }
        public DateTime? horaSalida { get; set; }
        public DateTime fechaNovedad { get; set; }    
        public decimal horas { get; set; }
        public string descripcion { get; set; }
        public virtual TipoNovedad? idTipoNovedadNavigation { get; set; }    
        public virtual Empleado? idEmpleadoNavigation { get; set; }    
    }
}
