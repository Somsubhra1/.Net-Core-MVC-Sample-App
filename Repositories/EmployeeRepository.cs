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

        public async Task DeleteEmployee(int employeeId)
        {
            var emp = await GetEmployeeByIdAsync(employeeId);
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.Where(emp => emp.EmployeeId == employeeId).FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee.EmployeeId;
        }
    }
}

