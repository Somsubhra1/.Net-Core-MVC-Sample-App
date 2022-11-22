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
    public class DesignationController : Controller
    {
        private IDesignationRepository _designationRepository;

        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        public async Task<IActionResult> GetDesignationsAsync()
        {
            var designations = await _designationRepository.GetAllDesignationsAsync();
            return View("Index", designations);
        }

        public IActionResult AddDesignation()
        {
            return View("AddDesignation");
        }

        [HttpPost]
        public async Task<IActionResult> AddDesignationAsync(Designation desi)
        {
            await _designationRepository.AddDesignation(desi);
            return RedirectToAction("GetDesignations");
        }

        public async Task<IActionResult> UpdateDesignation(int designationId)
        {
            Designation designation = await _designationRepository.GetDesignationByIdAsync(designationId);
            return View("UpdateDesignation", designation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDesignation(Designation designation)
        {
            await _designationRepository.UpdateDesignation(designation);

            return RedirectToAction("GetDesignations");
        }

        public async Task<IActionResult> DeleteDesignation(int designationId)
        {
            await _designationRepository.DeleteDesignation(designationId);
            return RedirectToAction("GetDesignations");
        }
    }
}

