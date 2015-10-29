using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Employee
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

        [Required]
        public int Position { get; set; }

    }
}
