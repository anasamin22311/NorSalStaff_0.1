using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.ViewModels.Account
{
    public class UsersViewModel
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SWWU { get; set; }
        public decimal Salary { get; set; }
        public decimal Target { get; set; }
        public decimal Achieved { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }
    }
}
