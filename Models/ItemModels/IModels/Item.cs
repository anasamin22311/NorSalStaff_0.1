using NorSalStaff_0._1.Models.VendorModels.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.ItemModels.IModels
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public List<IType> IType { get; set; } // The list of item types
        public string Description { get; set; }
        [Required, DefaultValue(false)]
        public bool IsAvailable { get; set; } // Checks if the item is available in the store or not
        [DefaultValue(0.0)]
        public List<RPrice> RPrice { get; set; } // The list of Retail Prices
        [DefaultValue(0.0)]
        public List<PPrice> PPrice { get; set; } // The list of Purchase Prices
        public List<VendorCompany> Vendor { get; set; } // The list of Vendors
    }
}
