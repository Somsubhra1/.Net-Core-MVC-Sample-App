using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeNumber { get; set; }

        public string Name { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public string Designation { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}

