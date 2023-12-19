using NorSalStaff_0._1.Models.OrderModels.OModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.OrderModels
{
    public class OrderRepository
    {
        private readonly AppDbContext context;
        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Order AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return (order);
        }
        public Order DeleteOrder(int id)
        {
            Order order = context.Orders.Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return (order);
        }
        public Order UpdateOrder(Order orderchanges)
        {
            var order = context.Orders.Attach(orderchanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return (orderchanges);
        }
        public Order GetOrder(int id)
        {
            return context.Orders.Find(id);
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders;
        }
    }
}
