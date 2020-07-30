﻿using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies.Shipping
{
    public class SwedishPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                /// TODO: Implement PostNord Shipping Integration

                Console.WriteLine("Order is shipped with PostNord");
            }
        }
    }
}
