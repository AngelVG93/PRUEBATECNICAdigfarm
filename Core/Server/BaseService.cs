using AutoMapper;
using Core.Interfaces.Repository;

namespace Core.Server
{
    public class BaseService<TEntity, TEntityDto>(IMapper mapper, IAdminInterfaces adminInterfaces) where TEntity : class
    {
        public readonly IAdminInterfaces _adminInterfaces = adminInterfaces;
    }
}
