using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoEmpledo
    {
        [Key]
        public int idTipoEmpleado { get; set; }  
        public string? nombre { get; set;}
        public virtual ICollection<Empleado>? Empleado { get; set; }     
    }
}
