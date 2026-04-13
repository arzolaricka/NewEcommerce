using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PaymentShippingModel
{
    public class Payment
    {
        public string Method { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }

        public Payment(string method, string accountName, string accountNumber)
        {
            Method = method;
            AccountName = accountName;
            AccountNumber = accountNumber;
        }
    }

    public class Shipping
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Shipping(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}