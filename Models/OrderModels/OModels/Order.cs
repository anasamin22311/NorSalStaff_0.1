using NorSalStaff_0._1.Models.CustomerModels.CModels;
using NorSalStaff_0._1.Models.ItemModels.IModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.OrderModels.OModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Item[] Item { get; set; }  //List of the items in each order
        [Required]
        public CustomerCompany Customer { get; set; }
        [DefaultValue(0.0)]
        public decimal EPrice { get; set; } // the expected price
        [Required]
        public OrderClass[] OClass { get; set; } // used to manage the workflow
    }
}
