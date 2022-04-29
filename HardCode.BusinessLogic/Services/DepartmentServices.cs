using AutoMapper;
using HardCode.Domain.Interfaces;
using HardCode.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.BusinessLogic.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IMapper _mapper;
        private readonly IRepositories _repositories;

        public DepartmentServices(IRepositories repositories, IMapper mapper)
        {
            _mapper = mapper;
            _repositories = repositories;
        }

        // Mahmoud Sami ! ... You Complate The Code!
    }
}
