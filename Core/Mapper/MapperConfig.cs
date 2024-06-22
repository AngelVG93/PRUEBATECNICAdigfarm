using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Core.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<RegistroEmpleado, RegistroEmpleadoDto>().ReverseMap();
            CreateMap<RegistroEmpleado, RegistroEmpleadoUpdateDto>().ReverseMap();
            CreateMap<TipoEmpledo, TipoEmpledoDto>().ReverseMap();
            CreateMap<TipoNovedad, TipoNovedadDto>().ReverseMap();
        }
    }
}
