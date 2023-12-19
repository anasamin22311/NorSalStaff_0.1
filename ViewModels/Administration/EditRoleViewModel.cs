using Microsoft.AspNetCore.Identity;
using NorSalStaff_0._1.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.ViewModels.Administration
{
    public class EditRoleViewModel
    {
        [Key]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsChecked { get; set; }
    }
}
