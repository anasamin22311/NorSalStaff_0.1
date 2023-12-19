using Microsoft.AspNetCore.Identity;
using NorSalStaff_0._1.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.ViewModels.Administration
{
    public class DetailRoleViewModel
    {
        [Key]
        public string Id { get; set; }
        public IdentityRole Role { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
