
using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface IRegistroEmpleadoRepository : IBaseRepository<RegistroEmpleado>
    {
        Task<List<RegistroEmpleado>> ConsultarNovedades(decimal cedula);
    }
}
