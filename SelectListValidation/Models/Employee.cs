using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListValidation.Models
{
    public class Employee
    {
      
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@",ErrorMessage ="Not a valid email format should be -----@-----")]
        public string Email { get; set; }
        [Required]
        public  Dept Department { get; set; }

    }
}
