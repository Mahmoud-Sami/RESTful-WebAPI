using HardCode.Domain.Dtos.Instructor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.Domain.Dtos.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name field required")]
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<InstructorDto> Instructors { get; set; }
    }
}
