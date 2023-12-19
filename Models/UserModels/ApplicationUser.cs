using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.UserModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime SWWU { get; set; }
        public string Image { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public decimal Target { get; set; }
        public decimal Achieved { get; set; }
    }
}
