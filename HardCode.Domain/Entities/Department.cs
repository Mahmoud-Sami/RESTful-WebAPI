using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardCode.Domain.Entities
{
    public class Department : EntityBase<int>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name field required")]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation Property
        // public IEnumerable<Instructor> Instructors { get; set; }
    }
}
