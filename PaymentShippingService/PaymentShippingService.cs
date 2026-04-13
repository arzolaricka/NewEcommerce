using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PaymentShippingModel;
using PaymentShippingDataService;

namespace PaymentShippingService
{
    public class PaymentShippingService
    {
        PaymentShippingDataService.PaymentShippingDataService data =
        new PaymentShippingDataService.PaymentShippingDataService();

        public void AddPayment(string method, string name, string number)
        {
            Payment payment = new Payment(method, name, number);
            data.AddPayment(payment);
        }

        public List<Payment> ViewPayments()
        {
            return data.GetPayments();
        }

        public void UpdatePayment(int index, string method, string name, string number)
        {
            Payment payment = new Payment(method, name, number);
            data.UpdatePayment(index, payment);
        }

        public void DeletePayment(int index)
        {
            data.DeletePayment(index);
        }

        public void AddShipping(string name, string address)
        {
            Shipping shipping = new Shipping(name, address);
            data.AddShipping(shipping);
        }

        public List<Shipping> ViewShipping()
        {
            return data.GetShippings();
        }

        public void UpdateShipping(int index, string name, string address)
        {
            Shipping shipping = new Shipping(name, address);
            data.UpdateShipping(index, shipping);
        }

        public void DeleteShipping(int index)
        {
            data.DeleteShipping(index);
        }
    }
}
