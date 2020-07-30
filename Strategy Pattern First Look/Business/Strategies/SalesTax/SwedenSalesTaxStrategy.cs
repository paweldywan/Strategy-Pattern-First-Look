using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies.SalesTax
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            //decimal totalTax = 0m;

            //foreach (var item in order.LineItems)
            //{
            //    switch (item.Key.ItemType)
            //    {
            //        case ItemType.Food:
            //            totalTax += (item.Key.Price * 0.06m) * item.Value;
            //            break;

            //        case ItemType.Literature:
            //            totalTax += (item.Key.Price * 0.08m) * item.Value;
            //            break;

            //        case ItemType.Service:
            //        case ItemType.Hardware:
            //            totalTax += (item.Key.Price * 0.25m) * item.Value;
            //            break;
            //    }
            //}

            //return totalTax;

            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();

            if(destination == origin)
            {
                return order.TotalPrice * 0.25m; 
            }

            return 0;
        }
    }
}
