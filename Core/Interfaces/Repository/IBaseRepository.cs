
namespace Core.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task AddRange(List<T> entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> Delete(T entity);
    }
}
