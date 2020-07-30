using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);

            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("paweld", "      ");

                client.Credentials = credentials;

                MailMessage mail = new MailMessage("p.dywan97@gmail.com", "p.dywan97@gmail.com")
                {
                    Subject = "We've created an invoice for your order",
                    Body = body
                };

                client.Send(mail);
            }
        }
    }
}
