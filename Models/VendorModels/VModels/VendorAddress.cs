using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.VendorModels.VModels
{
    public class VendorAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VAddress { get; set; }
    }
}
