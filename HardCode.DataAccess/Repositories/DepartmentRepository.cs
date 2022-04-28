using HardCode.Domain.Entities;
using HardCode.Domain.Interfaces;
using System.Threading.Tasks;

namespace HardCode.DataAccess.Repositories
{
    internal class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Department> UpdateDepartmentAsync(Department newDepartment)
        {
            var currentDepartment = await this.GetByIDAsync(newDepartment.Id);

            if (currentDepartment != null)
            {
                currentDepartment.Name = newDepartment.Name;
                currentDepartment.Description = newDepartment.Description;

            }

            return currentDepartment;
        }
    }
}
