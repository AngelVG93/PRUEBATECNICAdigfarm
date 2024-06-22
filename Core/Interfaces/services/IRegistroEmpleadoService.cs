using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces.services
{
    public interface IRegistroEmpleadoService
    {
        Task<List<RegistroEmpleado>> ConsultarNovedades(decimal cedula);
        Task<RegistroEmpleado> UpdateRegistroEntrada(RegistroEmpleado registroEntrada);
        Task<RegistroEmpleado> AddRegistroEntrada(RegistroEmpleado registroEntrada);
    }
}
