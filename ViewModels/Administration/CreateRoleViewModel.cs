using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.ViewModels.Administration
{
    public class CreateRoleViewModel
    {
        public CreateRoleViewModel()
        {
            Users = new List<UserRoleViewModel>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [Remote(action: "DoesRoleExist", controller: "Administration")]
        public string RoleName { get; set; }

        public List<UserRoleViewModel> Users { get; set; }
    }
}
