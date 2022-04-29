using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardCode.Domain.Dtos.Instructor
{
    public class CreateInstructorDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name field required")]
        [MinLength(length: 2, ErrorMessage = "Name length is less than 2 charachers")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int DepartmentID { get; set; }
    }
}
