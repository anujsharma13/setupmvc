using Imagetaghelper.Models;
using Imagetaghelper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagetaghelper.Controllers
{
    public class HomeController:Controller
    {
       private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
     
        public ViewResult IndexMethod()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
       public ViewResult Details(int? id)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
          return View(model);
        }
    }
}
