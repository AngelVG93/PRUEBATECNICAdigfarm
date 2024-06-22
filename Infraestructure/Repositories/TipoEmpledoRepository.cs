using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class TipoEmpledoRepository : BaseRepository<TipoEmpledo>, ITipoEmpledoRepository
    {
        public TipoEmpledoRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
