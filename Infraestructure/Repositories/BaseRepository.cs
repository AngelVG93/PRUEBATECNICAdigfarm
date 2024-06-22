using Core.Exceptions;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly pruebatecnicaDbContext _contex;
        protected readonly DbSet<T> _entities;
        public BaseRepository(pruebatecnicaDbContext contex)
        {
            _contex = contex;
            _entities = contex.Set<T>();
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                var result = await _entities.AddAsync(entity);
                return result.Entity;
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Name = "Base repository";
                logException.Message = "Error en AddAsync";
                throw new InternalServerErrorBusinessExceprions(logException);
            }
        }

        public virtual Task AddRange(List<T> entity)
        {
            try
            {
                return _entities.AddRangeAsync(entity); ;
            }
            catch (NotSupportedException ex)
            {
                LogException logException = new LogException();
                logException.Name = "Base repository";
                logException.Message = "Error al agregar AddRange";
                throw new InternalServerErrorBusinessExceprions(logException);
            }
        }

        public virtual Task<bool> Delete(T entity)
        {
            try
            {
                _entities.Remove(entity);
                return Task.FromResult(true);
            }
            catch (NotSupportedException)
            {
                LogException logException = new LogException();
                logException.Name = "Base repository";
                logException.Message = "Error en Delete";
                throw new InternalServerErrorBusinessExceprions(logException);
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Name = "Base repository";
                logException.Message = "Error en GetAll";
                throw new InternalServerErrorBusinessExceprions(logException);
            }
        }

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                T? t = await _entities.FindAsync(id);
                return t;
            }
            catch (Exception)
            {
                LogException logException = new LogException();
                logException.Name = "Base repository";
                logException.Message = "Error en GetById";
                throw new InternalServerErrorBusinessExceprions(logException);
            }
        }

        public virtual Task<T> UpdateAsync(T entity)
        {
            try
            {
                return Task.FromResult(_entities.Update(entity).Entity);
            }
            catch (Exception)
            {
                LogException logException = new LogException();
                logException.Name = "Base repository";
                logException.Message = "Error en UpdateAsync";
                throw new InternalServerErrorBusinessExceprions(logException);
            }
        }
    }
}
