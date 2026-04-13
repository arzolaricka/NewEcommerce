using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PaymentShippingModel;

namespace PaymentShippingDataService
{
    public class PaymentShippingDataService
    {
        private List<Payment> payments = new List<Payment>();
        private List<Shipping> shippings = new List<Shipping>();


        public void AddPayment(Payment payment)
        {
            payments.Add(payment);
        }

        public List<Payment> GetPayments()
        {
            return payments;
        }

        public void UpdatePayment(int index, Payment payment)
        {
            if (index >= 0 && index < payments.Count)
            {
                payments[index] = payment;
            }
        }

        public void DeletePayment(int index)
        {
            if (index >= 0 && index < payments.Count)
            {
                payments.RemoveAt(index);
            }
        }

      
        public void AddShipping(Shipping shipping)
        {
            shippings.Add(shipping);
        }

        public List<Shipping> GetShippings()
        {
            return shippings;
        }

        public void UpdateShipping(int index, Shipping shipping)
        {
            if (index >= 0 && index < shippings.Count)
            {
                shippings[index] = shipping;
            }
        }

        public void DeleteShipping(int index)
        {
            if (index >= 0 && index < shippings.Count)
            {
                shippings.RemoveAt(index);
            }
        }
    }
}