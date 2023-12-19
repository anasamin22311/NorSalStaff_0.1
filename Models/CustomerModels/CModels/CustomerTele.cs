using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.CustomerModels.CModels
{
    public class CustomerTele
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CTele { get; set; }
    }
}
