using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PaymentShippingModel;

namespace PaymentShippingDataService
{
    public class JsonDataService : IPaymentShippingDataService
    {
        private string paymentFile = "payments.json";
        private string shippingFile = "shippings.json";

        private string _jsonFileName;


        private List<Payment> LoadPayments()
        {
            if (!File.Exists(paymentFile)) return new List<Payment>();
            return JsonSerializer.Deserialize<List<Payment>>(File.ReadAllText(paymentFile));
        }

        private void SavePayments(List<Payment> payments)
        {
            File.WriteAllText(paymentFile, JsonSerializer.Serialize(payments));
        }

        private List<Shipping> LoadShippings()
        {
            if (!File.Exists(shippingFile)) return new List<Shipping>();
            return JsonSerializer.Deserialize<List<Shipping>>(File.ReadAllText(shippingFile));
        }

        private void SaveShippings(List<Shipping> shippings)
        {
            File.WriteAllText(shippingFile, JsonSerializer.Serialize(shippings));
        }

        public void AddPayment(Payment payment)
        {
            var list = LoadPayments();
            list.Add(payment);
            SavePayments(list);
        }

        public List<Payment> GetPayments() => LoadPayments();

        public void UpdatePayment(int index, Payment payment)
        {
            var list = LoadPayments();
            if (index >= 0 && index < list.Count)
            {
                list[index] = payment;
                SavePayments(list);
            }
        }

        public void DeletePayment(int index)
        {
            var list = LoadPayments();
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
                SavePayments(list);
            }
        }

        public void AddShipping(Shipping shipping)
        {
            var list = LoadShippings();
            list.Add(shipping);
            SaveShippings(list);
        }

        public List<Shipping> GetShippings() => LoadShippings();

        public void UpdateShipping(int index, Shipping shipping)
        {
            var list = LoadShippings();
            if (index >= 0 && index < list.Count)
            {
                list[index] = shipping;
                SaveShippings(list);
            }
        }

        public void DeleteShipping(int index)
        {
            var list = LoadShippings();
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
                SaveShippings(list);
            }
        }
    }
}
