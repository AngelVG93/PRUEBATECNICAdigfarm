using Core.Entities;
using Core.Interfaces.Repository;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class TipoNovedadRepository : BaseRepository<TipoNovedad>, ITipoNovedadRepository
    {
        public TipoNovedadRepository(pruebatecnicaDbContext contex) : base(contex)
        {
        }
    }
}
