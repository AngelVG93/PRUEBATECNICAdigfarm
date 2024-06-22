using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoNovedad
    {
        [Key]
        public int idTipoNovedad {  get; set; } 
        public string nombre { get; set; }
        public virtual ICollection<RegistroEmpleado>? RegistroEntrada { get; set; }   
    }
}
