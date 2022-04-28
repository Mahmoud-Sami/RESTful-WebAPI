using HardCode.DataAccess;
using HardCode.DataAccess.Repositories;
using HardCode.Domain.Interfaces;
using System.Threading.Tasks;

namespace HardCode.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            InstructorsRepository = new InstructorRepository(_context);
            DepartmentsRepository = new DepartmentRepository(_context);
        }


        public IInstructorRepository InstructorsRepository { get; init; }
        public IDepartmentRepository DepartmentsRepository { get; init; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
           await _context.DisposeAsync();
        }
    }
}
