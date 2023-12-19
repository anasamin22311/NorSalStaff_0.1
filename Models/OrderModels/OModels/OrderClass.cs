using NorSalStaff_0._1.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.OrderModels.OModels
{
    public class OrderClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public DateTime ReceivedDate { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}
