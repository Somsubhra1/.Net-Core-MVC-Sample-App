using System;
using MVCPractice.IRepositories;
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
	public class EmployeeRepository: IEmployeeRepository
	{
        private readonly List<Employee> _employees;
		public EmployeeRepository()
		{
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    Name = "A",
                    Department = "HR",
                    Designation = "IT"

                },
                new Employee()
                {
                    EmployeeId = 2,
                    Name = "B",
                    Department = "Admin",
                    Designation = "IT"

                },
                new Employee()
                {
                    EmployeeId = 3,
                    Name = "C",
                    Department = "ITIS",
                    Designation = "IT"

                },
            };
		}

        public int AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            return _employees.Count() - 1;
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}

