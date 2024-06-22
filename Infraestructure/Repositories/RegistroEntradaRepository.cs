using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class RegistroEntradaRepository : BaseRepository<RegistroEntrada>, IRegistroEntradaRepository
    {
        public RegistroEntradaRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }

        public async Task<List<RegistroEntrada>> ConsultarNovedades(decimal cedula)
        {
            var data = await _entities.Where(x => x.idEmpleadoNavigation.cedula == cedula).ToListAsync();
            return data;
        }
    }
}
