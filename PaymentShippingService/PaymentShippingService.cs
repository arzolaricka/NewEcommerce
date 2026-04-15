using System.Collections.Generic;
using PaymentShippingModel;
using PaymentShippingDataService;

namespace PaymentShippingService
{
    public class PaymentShippingService
    {
        private IPaymentShippingDataService data;

        public PaymentShippingService(IPaymentShippingDataService dataService)
        {
            data = dataService;
        }

        public void AddPayment(string method, string name, string number)
        {
            data.AddPayment(new Payment(method, name, number));
        }

        public List<Payment> ViewPayments()
        {
            return data.GetPayments();
        }

        public void UpdatePayment(int id, string method, string name, string number)
        {
            data.UpdatePayment(id, new Payment(method, name, number));
        }

        public void DeletePayment(int id)
        {
            data.DeletePayment(id);
        }

        public void AddShipping(string name, string address)
        {
            data.AddShipping(new Shipping(name, address));
        }

        public List<Shipping> ViewShipping()
        {
            return data.GetShippings();
        }

        public void UpdateShipping(int id, string name, string address)
        {
            data.UpdateShipping(id, new Shipping(name, address));
        }

        public void DeleteShipping(int id)
        {
            data.DeleteShipping(id);
        }
    }
}