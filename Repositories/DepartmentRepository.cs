using System;
using Microsoft.EntityFrameworkCore;
using MVCPractice.IRepositories;
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConnectionContext _context;

        public DepartmentRepository(DbConnectionContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.Where(dept => dept.IsActive == true).ToListAsync();
        }

        public async Task<int> AddDepartment(Department department)
        {
            department.ModifiedDate = DateTime.Now;
            department.IsActive = true;
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department.DepartmentId;
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department = await _context.Departments.Where(dept => dept.DepartmentId == departmentId).FirstAsync();
            department.IsActive = false;
            department.ModifiedDate = DateTime.Now;
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            var department = await _context.Departments.Where(dept => dept.DepartmentId == departmentId).FirstOrDefaultAsync();

            return department;
        }

        public async Task<int> UpdateDepartment(Department department)
        {
            department.ModifiedDate = DateTime.Now;
            department.IsActive = true;
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return department.DepartmentId;
        }
    }
}

