using DataAnnotationsExtensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_FinalExam_Net6.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Min(0)]
        public int EmployeeCount { get; set; }

    }
}
