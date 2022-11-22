using System;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}

