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

        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
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

        public async Task<IActionResult> UpdateEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            return View("UpdateEmployee", employee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);

            return RedirectToAction("GetEmployees");
        }

        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
            return RedirectToAction("GetEmployees");
        }
    }
}

