using System;
using System.Linq;
using System.Text.RegularExpressions;
using PaymentShippingService;
using PaymentShippingDataService;

class Program
{
    static void Main()
    {
        var Json = new JsonDataService();
        var service = new PaymentShippingService.PaymentShippingService(Json);

        string[] options = { "Cash", "GCash", "Credit Card", "PayPal" };

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
                Console.WriteLine("\nSelect Method:");
                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine(i + " - " + options[i]);

                int m = Convert.ToInt32(Console.ReadLine());
                string method = options[m];

                Console.Write("Name: ");
                string name = Console.ReadLine();

                string input = "";

                while (true)
                {
                    if (method == "GCash" || method == "Credit Card")
                        Console.Write("Enter your number: ");
                    else if (method == "PayPal")
                        Console.Write("Enter your email: ");
                    else
                    {
                        input = "N/A";
                        break;
                    }

                    input = Console.ReadLine();

                    if (method == "GCash" || method == "Credit Card")
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

                service.AddPayment(method, name, input);
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

                Console.WriteLine("\nSelect NEW Method:");
                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine(i + " - " + options[i]);

                int m = Convert.ToInt32(Console.ReadLine());
                string method = options[m];

                Console.Write("New Name: ");
                string name = Console.ReadLine();

                string input = "";

                while (true)
                {
                    if (method == "GCash" || method == "Credit Card")
                        Console.Write("Enter your number: ");
                    else if (method == "PayPal")
                        Console.Write("Enter your email: ");
                    else
                    {
                        input = "N/A";
                        break;
                    }

                    input = Console.ReadLine();

                    if (method == "GCash" || method == "Credit Card")
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

                service.UpdatePayment(id, method, name, input);
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

                service.AddShipping(name, addr);
            }

            else if (choice == 6)
            {
                var list = service.ViewShipping();

                foreach (var s in list)
                    Console.WriteLine($"ID:{s.Id} | {s.Name} | {s.Address}");

                Console.ReadKey();
            }

            else if (choice == 7)
            {
                var list = service.ViewShipping();

                foreach (var s in list)
                    Console.WriteLine($"ID:{s.Id} | {s.Name} | {s.Address}");

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

                service.UpdateShipping(id, name, addr);
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


    static bool IsNumber(string input)
    {
        return Regex.IsMatch(input, @"^[0-9]+$");
    }

    static bool IsEmail(string input)
    {
        return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}
