using System;
using MVCPractice.Models;

namespace MVCPractice.IRepositories
{
	public interface IEmployeeRepository
	{
		public List<Employee> GetEmployees();

        public int AddEmployee(Employee employee);


    }
}

