using System;
using PaymentShippingService;
using PaymentShippingDataService;

class Program
{
    static void Main()
    {
        var data = new DbDataService();
        var service = new PaymentShippingService.PaymentShippingService(data);

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

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Number: ");
                string num = Console.ReadLine();

                service.AddPayment(options[m], name, num);
            }

            else if (choice == 2)
            {
                var list = service.ViewPayments();

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i} - ID:{list[i].Id} | {list[i].Method} | {list[i].AccountName}");

                Console.ReadKey();
            }

            else if (choice == 3)
            {
                var list = service.ViewPayments();

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i} - ID:{list[i].Id} | {list[i].Method} | {list[i].AccountName}");

                Console.Write("Index to update: ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Name: ");
                string name = Console.ReadLine();

                Console.Write("New Number: ");
                string num = Console.ReadLine();

                service.UpdatePayment(list[index].Id, list[index].Method, name, num);
            }

            else if (choice == 4)
            {
                var list = service.ViewPayments();

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i} - ID:{list[i].Id} | {list[i].Method} | {list[i].AccountName}");

                Console.Write("Index to delete: ");
                int index = Convert.ToInt32(Console.ReadLine());

                service.DeletePayment(list[index].Id);
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

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i} - ID:{list[i].Id} | {list[i].Name} | {list[i].Address}");

                Console.ReadKey();
            }

            else if (choice == 7)
            {
                var list = service.ViewShipping();

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i} - ID:{list[i].Id} | {list[i].Name} | {list[i].Address}");

                Console.Write("Index to update: ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Name: ");
                string name = Console.ReadLine();

                Console.Write("New Address: ");
                string addr = Console.ReadLine();

                service.UpdateShipping(list[index].Id, name, addr);
            }

            else if (choice == 8)
            {
                var list = service.ViewShipping();

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i} - ID:{list[i].Id} | {list[i].Name} | {list[i].Address}");

                Console.Write("Index to delete: ");
                int index = Convert.ToInt32(Console.ReadLine());

                service.DeleteShipping(list[index].Id);
            }

            else if (choice == 9)
                return;
        }
    }
}

