using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.ViewModels.Account
{
    public class RoleUserViewModel
    {
        [Key]
        public string Id { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
    }
}
