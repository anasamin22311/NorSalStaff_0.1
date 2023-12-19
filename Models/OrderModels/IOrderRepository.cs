using NorSalStaff_0._1.Models.OrderModels.OModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.OrderModels
{
    interface IOrderRepository
    {
        Order AddOrder(Order order);
        Order DeleteOrder(int id);
        Order UpdateOrder(Order orderchanges);
        Order GetOrder(int id);
        IEnumerable<Order> GetAllOrders();
    }
}
