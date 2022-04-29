using HardCode.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HardCode.Domain.Interfaces
{
    public interface IInstructorRepository : IRepositoryBase<Instructor>
    {
        // Overload For Method => GetByIDAsync()
        Task<Instructor> GetByIDAsync(int id, Expression<Func<Instructor, object>> Include);

        public Task<Instructor> GetInstructorByIdAsync(int id);
        public Task<Instructor> UpdateInstructorAsync(Instructor newInstructor);

        /// <summary>
        ///     Get InstructorID by Instructor Email.
        /// </summary>
        /// <param name="email">Expresses Instructor Email.</param>
        /// <returns>return Instructor Id type of int, or Null.</returns>
        public Task<int?> GetIdByEmailAsync(string email);
    }
}
