using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPractice.IRepositories;
using MVCPractice.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCPractice.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: /<controller>/
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            return View("Index", employees);
        }

        public IActionResult AddEmployee()
        {
            return View("AddEmployee");
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return RedirectToAction("GetEmployees");
        }
    }
}

