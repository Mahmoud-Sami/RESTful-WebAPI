using AutoMapper;
using HardCode.BusinessLogic.Services;
using HardCode.Domain.Interfaces;
using HardCode.Domain.Interfaces.IServices;
using HardCode.Domain.Interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.DataAccess.UnitsOfWork
{
    public class Services : IServices
    {

        public Services(IRepositories repositories , IMapper mapper)
        {
            Instructor = new InstructorServices(repositories, mapper);
            Department = new DepartmentServices(repositories, mapper);
        }

        public IInstructorServices Instructor { get; private set; }

        public IDepartmentServices Department { get; private set; }
    }
}
