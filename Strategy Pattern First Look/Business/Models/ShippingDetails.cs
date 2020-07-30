using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Models
{
    public class ShippingDetails
    {
        public string OriginCountry { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationState { get; set; }
    }
}
