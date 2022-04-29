using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIDAsync(int id);

        // Overload For Method => GetAllAsync()
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> Include);

        Task AddAsync(T entity);
        Task AddRagneAsync(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRagne(IEnumerable<T> entities);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
