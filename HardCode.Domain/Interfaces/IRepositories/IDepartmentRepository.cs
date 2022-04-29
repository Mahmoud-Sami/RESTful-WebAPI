using HardCode.Domain.Entities;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        public Task<Department> UpdateDepartmentAsync(Department newDepartment);
    }
}
