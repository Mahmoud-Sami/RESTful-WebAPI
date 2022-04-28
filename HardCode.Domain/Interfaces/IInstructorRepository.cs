using HardCode.Domain.Entities;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces
{
    public interface IInstructorRepository : IRepositoryBase<Instructor>
    {
        public Task<Instructor> GetInstructorByIdAsync(int id);
        public Task<Instructor> UpdateInstructorAsync(Instructor newInstructor);
    }
}
