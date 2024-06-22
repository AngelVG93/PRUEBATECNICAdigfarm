
using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface IRegistroEntradaRepository : IBaseRepository<RegistroEntrada>
    {
        Task<List<RegistroEntrada>> ConsultarNovedades(decimal cedula);
    }
}
