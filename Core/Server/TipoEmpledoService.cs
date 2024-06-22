using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.services;

namespace Core.Server
{
    public class TipoEmpledoService : BaseService<TipoEmpledo, TipoEmpledoDto>, ITipoEmpledoService
    {
        public TipoEmpledoService(IMapper mapper, IAdminInterfaces adminInterfaces) : base(mapper, adminInterfaces)
        {
        }
    }
}
