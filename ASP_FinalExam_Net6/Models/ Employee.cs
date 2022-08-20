using System;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_FinalExam_Net6.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsManager { get; set; }

        [Key, ForeignKey("Department")]
        public int Id { get;set; }

    }
}

