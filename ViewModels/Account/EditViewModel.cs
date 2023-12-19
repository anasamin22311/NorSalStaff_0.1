using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.ViewModels.Account
{
    public class EditViewModel
    {
        public EditViewModel()
        {
            Roles = new List<RoleUserViewModel>();
        }
        [Key]
        [Required]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime SWWU { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Target { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Achieved { get; set; }

        [DataType(DataType.ImageUrl)]
        [NotMapped]
        public IFormFile Image { get; set; }
        public string SImage { get; set; }
        public List<RoleUserViewModel> Roles { get; set; }
    }
}
