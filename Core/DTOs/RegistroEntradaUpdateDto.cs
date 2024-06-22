using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegistroEntradaUpdateDto
    {
        public int idRegistroEntrada { get; set; }
        public int idTipoNovedad { get; set; }
        public string descripcion { get; set; }
    }
}
