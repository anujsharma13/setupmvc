using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListValidation.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="anuj",Department=Dept.IT,Email="anuj@gmail.com"},
                 new Employee(){Id=2,Name="abhinav",Department=Dept.IT,Email="abhi@gmail.com"},
                  new Employee(){Id=3,Name="akshat",Department=Dept.IT,Email="akshat@gmail.com"},

            };
        }

        public Employee Add(Employee emp)
        {
           emp.Id=_employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(emp);
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
