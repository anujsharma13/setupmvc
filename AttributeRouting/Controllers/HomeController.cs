using AttributeRouting.Models;
using AttributeRouting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeRouting.Controllers
{
    [Route("home")]
    public class HomeController:Controller
    {
       private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       [Route("")]   //this means at the root url localhost this action method works
        [Route("indexmethod")]
        [Route("~/")]  // we have added it bcz we have used the attribute to the class and home page will shown by this
        //when ~/ is combined on a route at that time the route of the class is iggnored
        //on the above three routes this method will call
        public ViewResult IndexMethod()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
        [Route("Details/{id}")]  // the variable in {} it is mandatory
        //we have passes int id as nullable if user enter the value then it will open that otherwise 1 as default
        public ViewResult List(int? id)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
           // in this example we have different name in route and we want that the list method will bind with details view so we have to pass complete path
            return View("~/Views/Home/Details.cshtml",model);
        }
    }
}
