using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.CustomerModels.CModels
{
    public class CustomerCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CCompanyName { get; set; }
        [Required]
        public Customer[] Customer { get; set; } // List of the Company's employees' names
        [Required]
        public CustomerAddress[] CAddress { get; set; } // List of Addresses to the Company
        [Required, DefaultValue(false)]
        public bool LocalOrInternational { get; set; } // Is it a local or an international Company 
        [Required, DefaultValue(0.0)]
        public decimal OwnMoney { get; set; } // Money that we own with that Company
        [Required, DefaultValue(0.0)]
        public decimal OweMoney { get; set; } // Money that we owe for that Company
    }
}
