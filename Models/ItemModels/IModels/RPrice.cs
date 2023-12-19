using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.ItemModels.IModels
{
    public class RPrice
    {
        [Key]
        public int Id { get; set; }
        [Required, DefaultValue(0.0)]
        public decimal RetailPrice { get; set; }
        [Required]
        public DateTime RetailDate { get; set; }
    }
}
