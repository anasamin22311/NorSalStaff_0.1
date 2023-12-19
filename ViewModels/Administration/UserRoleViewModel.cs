using NorSalStaff_0._1.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace NorSalStaff_0._1.ViewModels.Administration
{
    public class UserRoleViewModel
    {
        [Key]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsChecked { get; set; }
    }
}