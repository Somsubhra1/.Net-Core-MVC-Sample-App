using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPractice.IRepositories;
using MVCPractice.Models;
using MVCPractice.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCPractice.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View("Index", departments);
        }

        public IActionResult AddDepartment()
        {
            return View("AddDepartment");
        }

        [HttpPost]
        public IActionResult AddDepartment(Department dept)
        {
            _departmentRepository.AddDepartment(dept);
            return RedirectToAction("GetDepartments");
        }

        public async Task<IActionResult> UpdateDepartment(int departmentId)
        {
            Department department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);
            return View("UpdateDepartment", department);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            await _departmentRepository.UpdateDepartment(department);

            return RedirectToAction("GetDepartments");
        }

        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            await _departmentRepository.DeleteDepartment(departmentId);
            return RedirectToAction("GetDepartments");
        }
    }
}

