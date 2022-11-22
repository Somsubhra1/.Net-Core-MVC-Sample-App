using System;
namespace MVCPractice.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        public List<Department> Departments { get; set; }

        public List<Designation> Designations { get; set; }
    }
}

