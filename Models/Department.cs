using System;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}

