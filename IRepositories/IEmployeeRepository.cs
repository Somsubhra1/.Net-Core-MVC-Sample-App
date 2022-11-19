using System;
using MVCPractice.Models;

namespace MVCPractice.IRepositories
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeesAsync();

        public Task<int> AddEmployee(Employee employee);
    }
}

