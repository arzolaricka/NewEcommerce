using System.Collections.Generic;
using PaymentShippingModel;

namespace PaymentShippingDataService
{
    public interface IPaymentShippingDataService
    {
        void AddPayment(Payment payment);
        List<Payment> GetPayments();
        void UpdatePayment(int id, Payment payment);
        void DeletePayment(int id);

        void AddShipping(Shipping shipping);
        List<Shipping> GetShippings();
        void UpdateShipping(int id, Shipping shipping);
        void DeleteShipping(int id);
    }
}
