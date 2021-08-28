using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Models
{
    public class Employee
    {
        [MaxLength(50,ErrorMessage ="not a valid length ") ]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@",ErrorMessage ="Not a valid email format should be -----@-----")]
        public string Email { get; set; }
        public  Dept Department { get; set; }

    }
}
