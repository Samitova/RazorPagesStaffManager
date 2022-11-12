using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesStaffManager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Please, enter the name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please, enter the e-mail")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Department? Department { get; set; }

        public bool Notify { get; set; }

    }
}
