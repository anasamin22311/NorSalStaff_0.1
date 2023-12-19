using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.VendorModels.VModels
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VName { get; set; }
        public string Image { get; set; }
        public VendorEmail[] VEmail { get; set; } // List of Emails to the Company
        public VendorLink[] VLink { get; set; } // List of Links to the Company
        public VendorTele[] VTele { get; set; } // List of Teles to the Company
    }
}
