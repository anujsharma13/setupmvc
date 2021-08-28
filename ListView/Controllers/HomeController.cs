﻿using Microsoft.AspNetCore.Mvc;
using setupmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viewmodel.ViewModels;

namespace setupmvc.Controllers
{
    public class HomeController:Controller
    {
       private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
        public ViewResult Details()
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };
           
            return View(model);
        }
    }
}
