using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Models
{
    public class Payment
    {
        public PaymentProvider PaymentProvider { get; set; }

        public decimal Amount { get; set; }
    }
}
