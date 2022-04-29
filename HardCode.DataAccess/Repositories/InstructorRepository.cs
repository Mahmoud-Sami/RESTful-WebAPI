using HardCode.Domain.Entities;
using HardCode.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace HardCode.DataAccess.Repositories
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Instructor> GetByIDAsync(int id, Expression<Func<Instructor, object>> Include)
            => await _context.Set<Instructor>().Where(ins => ins.Id == id)
                .Include(Include).SingleOrDefaultAsync();

        

        public async Task<int?> GetIdByEmailAsync(string email)
        {
            if (!AnyAsync(ins => ins.Email == email).Result)
                return null;

            return await _context.Set<Instructor>()
                .Where(ins => ins.Email == email)
                .Select(ins => ins.Id).SingleOrDefaultAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors.Include(i => i.Department).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Instructor> UpdateInstructorAsync(Instructor newInstructor)
        {
            var currentInstructor = await this.GetByIDAsync(newInstructor.Id);

            if (currentInstructor != null)
            {
                currentInstructor.Name = newInstructor.Name;
                currentInstructor.Email = newInstructor.Email;
                currentInstructor.BirthDate = newInstructor.BirthDate;
                currentInstructor.DepartmentID = newInstructor.DepartmentID;
            }

            return currentInstructor;
        }
    }
}
