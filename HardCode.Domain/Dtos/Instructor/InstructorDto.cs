using HardCode.Domain.Dtos.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardCode.Domain.Dtos;

namespace HardCode.Domain.Dtos.Instructor
{
    public class InstructorDto : CreateInstructorDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
    }
}
