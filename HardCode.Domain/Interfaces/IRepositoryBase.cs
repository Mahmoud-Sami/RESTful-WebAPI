using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {

        Task<T> GetByIDAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);
        Task AddRagneAsync(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRagne(IEnumerable<T> entities);
    }
}
