using System;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeNumber { get; set; }

        public string Name { get; set; }

        public int Department { get; set; }

        public string Designation { get; set; }
    }
}

