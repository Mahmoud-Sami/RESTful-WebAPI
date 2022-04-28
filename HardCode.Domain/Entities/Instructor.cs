using System;
using System.ComponentModel.DataAnnotations;

namespace HardCode.Domain.Entities
{
    public class Instructor : EntityBase<int>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name field required")]
        [MinLength(length:2, ErrorMessage = "Name length is less than 2 charachers")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        // Navigation Property
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
