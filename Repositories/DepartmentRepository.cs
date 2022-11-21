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
            return await _context.Departments.ToListAsync();
        }
    }
}

