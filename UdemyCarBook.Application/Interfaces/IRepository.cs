

using System.Linq.Expressions;

namespace UdemyCarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

        Task<List<T>> GetFilteredList(Expression<Func<T, bool>> where);
        Task<T?> GetByFilter(Expression<Func<T, bool>> where);
    }
}
