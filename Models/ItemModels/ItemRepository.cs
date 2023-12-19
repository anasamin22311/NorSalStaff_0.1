using NorSalStaff_0._1.Models.ItemModels.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.ItemModels
{
    public class ItemRepository
    {
        private readonly AppDbContext context;
        public ItemRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Item AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return (item);
        }
        public Item DeleteItem(int id)
        {
            Item item = context.Items.Find(id);
            if (item != null)
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
            return (item);
        }
        public Item UpdateItem(Item itemchanges)
        {
            var item = context.Items.Attach(itemchanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return (itemchanges);
        }
        public Item GetItem(int id)
        {
            return context.Items.Find(id);
        }
        public IEnumerable<Item> GetAllItems()
        {
            return context.Items;
        }
    }
}
