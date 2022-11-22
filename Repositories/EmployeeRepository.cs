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
            employee.ModifiedDate = DateTime.Now;
            employee.IsActive = true;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.EmployeeId;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.Where(emp => emp.EmployeeId == employeeId).FirstAsync();
            employee.IsActive = false;
            employee.ModifiedDate = DateTime.Now;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.Where(emp => emp.EmployeeId == employeeId).FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Where(emp => emp.IsActive == true).Include(e => e.Department).Include(e => e.Designation).ToListAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            employee.ModifiedDate = DateTime.Now;
            employee.IsActive = true;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee.EmployeeId;
        }
    }
}

