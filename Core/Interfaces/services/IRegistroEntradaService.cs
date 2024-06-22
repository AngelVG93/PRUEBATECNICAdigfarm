using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces.services
{
    public interface IRegistroEntradaService
    {
        Task<List<RegistroEntrada>> ConsultarNovedades(decimal cedula);
        Task<RegistroEntrada> UpdateRegistroEntrada(RegistroEntrada registroEntrada);
        Task<RegistroEntrada> AddRegistroEntrada(RegistroEntrada registroEntrada);
    }
}
