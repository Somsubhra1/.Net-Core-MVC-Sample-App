using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MVCPractice.IRepositories;
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConnectionContext _context;
        public EmployeeRepository(DbConnectionContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.EmployeeId;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}

