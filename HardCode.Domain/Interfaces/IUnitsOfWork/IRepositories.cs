using System;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces
{
    public interface IRepositories : IDisposable
    {
        IInstructorRepository InstructorsRepository { get; init; }
        IDepartmentRepository DepartmentsRepository { get; init; }
        Task<int> SaveAsync();
    }
}
