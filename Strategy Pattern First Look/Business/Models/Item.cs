using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Models
{
    public class Item
    {
        public Item(string articleId, string name, decimal price, ItemType itemType)
        {
            Id = articleId;
            Name = name;
            Price = price;
            ItemType = itemType;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ItemType ItemType { get; set; }
    }
}
