using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.services;

namespace Core.Server
{
    public class EmpleadoService : BaseService<Empleado, EmpleadoDto>, IEmpleadoService
    {
        public EmpleadoService(IMapper mapper, IAdminInterfaces adminInterfaces) : base(mapper, adminInterfaces)
        {
        }
    }
}
