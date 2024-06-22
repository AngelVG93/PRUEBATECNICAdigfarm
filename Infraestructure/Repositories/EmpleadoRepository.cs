using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class EmpleadoRepository : BaseRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
