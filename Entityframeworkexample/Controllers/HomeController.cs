using Entityframeworkexample.Models;
using Entityframeworkexample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entityframeworkexample.Controllers
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
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee newemployee = _employeeRepository.Add(emp);
                return RedirectToAction("Details", new { id = emp.Id });

            }
            return View();  //again redirect to same page
        }
    }
}
