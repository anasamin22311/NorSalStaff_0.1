using NorSalStaff_0._1.Models.ItemModels.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.ItemModels
{
    interface IItemRepository
    {
        Item AddItem(Item item);
        Item DeleteItem(int id);
        Item UpdateItem(Item itemchanges);
        Item GetItem(int id);
        IEnumerable<Item> GetAllItems();
    }
}
