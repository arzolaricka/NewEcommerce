using System;
using System.Linq;
using System.Text.RegularExpressions;
using PaymentShippingService;
using PaymentShippingDataService;
using System.Text.RegularExpressions;

using PaymentShippingDataService;
using System.Text.RegularExpressions;
using PaymentShippingDataService;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var Data = new DbDataService();
        var service = new PaymentShippingService.PaymentShippingService(Data);

        string[] options = { "Cash", "GCash", "Credit Card", "PayPal", "Bank Account" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== PAYMENT & SHIPPING SYSTEM ====");
            Console.WriteLine("1 Add Payment");
            Console.WriteLine("2 View Payments");
            Console.WriteLine("3 Update Payment");
            Console.WriteLine("4 Delete Payment");
            Console.WriteLine("5 Add Shipping");
            Console.WriteLine("6 View Shipping");
            Console.WriteLine("7 Update Shipping");
            Console.WriteLine("8 Delete Shipping");
            Console.WriteLine("9 Exit");

            Console.Write("\nChoice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                CollectAndAddPayment(service, options);
            }

            else if (choice == 2)
            {
                var list = service.ViewPayments();

                foreach (var p in list)
                    Console.WriteLine($"ID:{p.Id} | {p.Method} | {p.AccountName} | {p.AccountNumber}");

                Console.ReadKey();
            }

            else if (choice == 3)
            {
                var list = service.ViewPayments();

                foreach (var p in list)
                    Console.WriteLine($"ID:{p.Id} | {p.Method} | {p.AccountName}");

                Console.Write("Enter ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var item = list.FirstOrDefault(x => x.Id == id);

                if (item == null)
                {
                    Console.WriteLine("ID not found!");
                    Console.ReadKey();
                    continue;
                }

                CollectAndUpdatePayment(service, options, id);
            }

            else if (choice == 4)
            {
                var list = service.ViewPayments();

                foreach (var p in list)
                    Console.WriteLine($"ID:{p.Id} | {p.Method} | {p.AccountName}");

                Console.Write("Enter ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                service.DeletePayment(id);
            }

            else if (choice == 5)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Address: ");
                string addr = Console.ReadLine();

                var (lat, lng) = CollectMapPin();

                service.AddShipping(name, addr, lat, lng);
            }

            else if (choice == 6)
            {
                var list = service.ViewShipping();

                foreach (var s in list)
                    Console.WriteLine($"ID:{s.Id} | {s.Name} | {s.Address} | 📍 {s.Latitude}, {s.Longitude}");

                Console.ReadKey();
            }

            else if (choice == 7)
            {
                var list = service.ViewShipping();

                foreach (var s in list)
                    Console.WriteLine($"ID:{s.Id} | {s.Name} | {s.Address} | 📍 {s.Latitude}, {s.Longitude}");

                Console.Write("Enter ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var item = list.FirstOrDefault(x => x.Id == id);

                if (item == null)
                {
                    Console.WriteLine("ID not found!");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("New Name: ");
                string name = Console.ReadLine();

                Console.Write("New Address: ");
                string addr = Console.ReadLine();

                var (lat, lng) = CollectMapPin();

                service.UpdateShipping(id, name, addr, lat, lng);
            }

            else if (choice == 8)
            {
                var list = service.ViewShipping();

                foreach (var s in list)
                    Console.WriteLine($"ID:{s.Id} | {s.Name} | {s.Address}");

                Console.Write("Enter ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                service.DeleteShipping(id);
            }

            else if (choice == 9)
                return;
        }
    }

    // ─── Collect payment info and ADD ───────────────────────────────────────

    static void CollectAndAddPayment(PaymentShippingService.PaymentShippingService service, string[] options)
    {
        Console.WriteLine("\nSelect Method:");
        for (int i = 0; i < options.Length; i++)
            Console.WriteLine(i + " - " + options[i]);

        int m = Convert.ToInt32(Console.ReadLine());
        string method = options[m];

        if (method == "Credit Card")
        {
            var (cardNumber, expiry, cvv, nameOnCard) = CollectCreditCardDetails();
            service.AddCreditCardPayment(nameOnCard, cardNumber, expiry, cvv);
        }
        else if (method == "Bank Account")
        {
            var (bankName, accountNumber, accountHolder) = CollectBankAccountDetails();
            service.AddBankAccountPayment(bankName, accountHolder, accountNumber);
        }
        else
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            string input = CollectAccountInput(method);
            service.AddPayment(method, name, input);
        }
    }

    // ─── Collect payment info and UPDATE ────────────────────────────────────

    static void CollectAndUpdatePayment(PaymentShippingService.PaymentShippingService service, string[] options, int id)
    {
        Console.WriteLine("\nSelect NEW Method:");
        for (int i = 0; i < options.Length; i++)
            Console.WriteLine(i + " - " + options[i]);

        int m = Convert.ToInt32(Console.ReadLine());
        string method = options[m];

        if (method == "Credit Card")
        {
            var (cardNumber, expiry, cvv, nameOnCard) = CollectCreditCardDetails();
            service.UpdateCreditCardPayment(id, nameOnCard, cardNumber, expiry, cvv);
        }
        else if (method == "Bank Account")
        {
            var (bankName, accountNumber, accountHolder) = CollectBankAccountDetails();
            service.UpdateBankAccountPayment(id, bankName, accountHolder, accountNumber);
        }
        else
        {
            Console.Write("New Name: ");
            string name = Console.ReadLine();
            string input = CollectAccountInput(method);
            service.UpdatePayment(id, method, name, input);
        }
    }

    // ─── Google Maps Pin ─────────────────────────────────────────────────────

    static (double latitude, double longitude) CollectMapPin()
    {
        Console.WriteLine("\n--- Google Maps Pin ---");
        Console.WriteLine("Enter your location coordinates.");
        Console.WriteLine("Tip: Open Google Maps, long press your location, and copy the coordinates shown.");

        double latitude = 0;
        while (true)
        {
            Console.Write("Latitude (e.g. 14.5995): ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out latitude))
                break;
            Console.WriteLine("❌ Invalid latitude! Must be a number.");
        }

        double longitude = 0;
        while (true)
        {
            Console.Write("Longitude (e.g. 120.9842): ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out longitude))
                break;
            Console.WriteLine("❌ Invalid longitude! Must be a number.");
        }

        Console.WriteLine($"✅ Pin set: {latitude}, {longitude}");
        return (latitude, longitude);
    }

    // ─── Credit Card ────────────────────────────────────────────────────────

    static (string cardNumber, string expiry, string cvv, string nameOnCard) CollectCreditCardDetails()
    {
        Console.WriteLine("\n--- Credit Card Details ---");
        Console.WriteLine("Your card details are protected.");

        string cardNumber = "";
        while (true)
        {
            Console.Write("Card Number (16 digits): ");
            cardNumber = Console.ReadLine().Replace(" ", "");
            if (!Regex.IsMatch(cardNumber, @"^\d{16}$"))
                Console.WriteLine("❌ Card number must be exactly 16 digits!");
            else
                break;
        }

        string expiry = "";
        while (true)
        {
            Console.Write("Expiry Date (MM/YY): ");
            expiry = Console.ReadLine();
            if (!Regex.IsMatch(expiry, @"^(0[1-9]|1[0-2])\/\d{2}$"))
                Console.WriteLine("❌ Expiry must be in MM/YY format!");
            else
                break;
        }

        string cvv = "";
        while (true)
        {
            Console.Write("CVV (3-4 digits): ");
            cvv = Console.ReadLine();
            if (!Regex.IsMatch(cvv, @"^\d{3,4}$"))
                Console.WriteLine("❌ CVV must be 3 or 4 digits!");
            else
                break;
        }

        Console.Write("Name on Card: ");
        string nameOnCard = Console.ReadLine();

        Console.WriteLine($"\n✅ Credit Card: **** **** **** {cardNumber.Substring(cardNumber.Length - 4)}");
        return (cardNumber, expiry, cvv, nameOnCard);
    }

    // ─── Bank Account ────────────────────────────────────────────────────────

    static (string bankName, string accountNumber, string accountHolder) CollectBankAccountDetails()
    {
        Console.WriteLine("\n--- Bank Account Details ---");

        Console.Write("Bank Name (e.g. BDO, BPI, Metrobank): ");
        string bankName = Console.ReadLine();

        string accountNumber = "";
        while (true)
        {
            Console.Write("Account Number: ");
            accountNumber = Console.ReadLine();
            if (!IsNumber(accountNumber))
                Console.WriteLine("❌ Account number must be digits only!");
            else
                break;
        }

        Console.Write("Account Holder Name: ");
        string accountHolder = Console.ReadLine();

        Console.WriteLine($"\n✅ Bank Account: {bankName} ********{accountNumber.Substring(accountNumber.Length - 4)}");
        return (bankName, accountNumber, accountHolder);
    }

    // ─── Other payment inputs (GCash, PayPal, Cash) ─────────────────────────

    static string CollectAccountInput(string method)
    {
        string input = "";
        while (true)
        {
            if (method == "GCash")
                Console.Write("Enter your GCash number: ");
            else if (method == "PayPal")
                Console.Write("Enter your PayPal email: ");
            else
            {
                input = "N/A";
                break;
            }

            input = Console.ReadLine();

            if (method == "GCash")
            {
                if (!IsNumber(input))
                {
                    Console.WriteLine("❌ Must be numbers only!");
                    continue;
                }
            }
            else if (method == "PayPal")
            {
                if (!IsEmail(input))
                {
                    Console.WriteLine("❌ Must be a valid email!");
                    continue;
                }
            }

            break;
        }
        return input;
    }

    // ─── Validators ─────────────────────────────────────────────────────────

    static bool IsNumber(string input)
    {
        return Regex.IsMatch(input, @"^[0-9]+$");
    }

    static bool IsEmail(string input)
    {
        return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}