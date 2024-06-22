using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Server
{
    public class TipoNovedadService : BaseService<TipoNovedad, TipoNovedadDto>, ITipoNovedadService
    {
        public TipoNovedadService(IMapper mapper, IAdminInterfaces adminInterfaces) : base(mapper, adminInterfaces)
        {
        }
    }
}
