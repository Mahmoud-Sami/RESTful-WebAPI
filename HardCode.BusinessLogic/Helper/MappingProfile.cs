using AutoMapper;
using HardCode.Domain.Dtos.Department;
using HardCode.Domain.Dtos.Instructor;
using HardCode.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.BusinessLogic.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instructor, InstructorDto>()
                .ForMember(dest => dest.DepartmentName, src => src.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.DepartmentDescription, src => src.MapFrom(src => src.Department.Description)).ReverseMap();
           
            CreateMap<Instructor, CreateInstructorDto>().ReverseMap();
        }
    }
}
