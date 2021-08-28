using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace listviewemployee.Models
{
   public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployees();
    }
}
