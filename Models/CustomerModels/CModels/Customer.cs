using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.CustomerModels.CModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CName { get; set; }
        public string Image { get; set; }
        public CustomerEmail[] CEmail { get; set; } // List of Emails to the Company
        public CustomerLink[] CLink { get; set; } // List of Links to the Company
        public CustomerTele[] CTele { get; set; } // List of Teles to the Company
    }
}
