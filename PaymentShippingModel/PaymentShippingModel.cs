using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PaymentShippingModel
{
    
        public class Payment
        {
            public int Id { get; set; }
            public string Method { get; set; }
            public string AccountName { get; set; }
            public string AccountNumber { get; set; }

            public Payment(int id, string method, string name, string number)
            {
                Id = id;
                Method = method;
                AccountName = name;
                AccountNumber = number;
            }

            public Payment(string method, string name, string number)
            {
                Method = method;
                AccountName = name;
                AccountNumber = number;
            }
        }
    }

    public class Shipping
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public Shipping(int id, string name, string address)
            {
                Id = id;
                Name = name;
                Address = address;
            }

            public Shipping(string name, string address)
            {
                Name = name;
                Address = address;
            }
        }
    