﻿using System.ComponentModel.DataAnnotations;

namespace CRUDAppUsingADO.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Designation { get; set; }
        public decimal Salary { get; set; }

        [Required]
        public string City { get; set; }
    }
}
