using Strategy_Pattern_First_Look.Business.Strategies.Invoice;
using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using Strategy_Pattern_First_Look.Business.Strategies.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; set; } = new Dictionary<Item, int>();

        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

        public ShippingDetails ShippingDetails { get; set; }

        public List<Payment> SelectedPayments { get; set; } = new List<Payment>();

        public List<Payment> FinalizedPayments { get; set; } = new List<Payment>();

        public decimal AmountDue => TotalPrice + GetTax() - FinalizedPayments.Sum(p => p.Amount);

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public IInvoiceStrategy InvoiceStrategy { get; set; }

        public IShippingStrategy ShippingStrategy { get; set; }

        public decimal GetTax(ISalesTaxStrategy salesTaxStrategy = default)
        {
            var strategy = salesTaxStrategy ?? SalesTaxStrategy;

            if (strategy == null)
            {
                return 0m;
            }

            return strategy.GetTaxFor(this);
        }

        public void FinalizeOrder()
        {
            if (SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice
                                          && AmountDue > 0
                                          && ShippingStatus == ShippingStatus.WaitingForPayment))
            {
                InvoiceStrategy.Generate(this);

                ShippingStatus = ShippingStatus.ReadyForShipment;
            }
            else if (AmountDue > 0)
            {
                throw new Exception("Unable to finalize order");
            }

            ShippingStrategy.Ship(this);
        }
    }
}
