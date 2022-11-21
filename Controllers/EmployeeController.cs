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
        private IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return View("Index", employees);
        }

        public async Task<IActionResult> AddEmployee()
        {
            EmployeeViewModel evm = new EmployeeViewModel()
            {
                Departments = await _departmentRepository.GetAllDepartmentsAsync()
            };
            return View("AddEmployee", evm);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel evm)
        {
            _employeeRepository.AddEmployee(evm.Employee);
            return RedirectToAction("GetEmployees");
        }

        public async Task<IActionResult> UpdateEmployee(int employeeId)
        {
            EmployeeViewModel evm = new EmployeeViewModel()
            {
                Employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId),
                Departments = await _departmentRepository.GetAllDepartmentsAsync()
            };
            return View("UpdateEmployee", evm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel evm)
        {
            await _employeeRepository.UpdateEmployee(evm.Employee);

            return RedirectToAction("GetEmployees");
        }

        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
            return RedirectToAction("GetEmployees");
        }
    }
}

