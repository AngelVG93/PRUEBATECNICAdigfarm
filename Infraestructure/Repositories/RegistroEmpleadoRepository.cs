using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class RegistroEmpleadoRepository : BaseRepository<RegistroEmpleado>, IRegistroEmpleadoRepository
    {
        public RegistroEmpleadoRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }

        public async Task<List<RegistroEmpleado>> ConsultarNovedades(decimal cedula)
        {
            var data = await _entities.Where(x => x.idEmpleadoNavigation.cedula == cedula).ToListAsync();
            return data;
        }
    }
}
