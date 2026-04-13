using System;
using PaymentShippingService;

class Program
{
    static void Main()
    {
        PaymentShippingService.PaymentShippingService service =
        new PaymentShippingService.PaymentShippingService();

        string[] paymentOptions = { "Cash", "GCash", "Credit Card", "PayPal" };

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

            switch (choice)
            {
                case 1:

                    Console.WriteLine("\nSelect Payment Method:");

                    for (int i = 0; i < paymentOptions.Length; i++)
                    {
                        Console.WriteLine(i + " - " + paymentOptions[i]);
                    }

                    Console.Write("Choice: ");
                    int methodChoice = Convert.ToInt32(Console.ReadLine());

                    string method = paymentOptions[methodChoice];

                    Console.Write("Account Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Account Number / Email: ");
                    string number = Console.ReadLine();

                    service.AddPayment(method, name, number);

                    Console.WriteLine("Payment Added!");
                    Console.ReadKey();
                    break;

                case 2:

                    var payments = service.ViewPayments();

                    Console.WriteLine("\nPAYMENT LIST");

                    for (int i = 0; i < payments.Count; i++)
                    {
                        Console.WriteLine(i + " | " +
                        payments[i].Method + " | " +
                        payments[i].AccountName + " | " +
                        payments[i].AccountNumber);
                    }

                    Console.ReadKey();
                    break;

                case 3:

                    var updatePayments = service.ViewPayments();

                    for (int i = 0; i < updatePayments.Count; i++)
                    {
                        Console.WriteLine(i + " | " +
                        updatePayments[i].Method + " | " +
                        updatePayments[i].AccountName + " | " +
                        updatePayments[i].AccountNumber);
                    }

                    Console.Write("\nEnter index to update: ");
                    int updateIndex = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nSelect New Method:");

                    for (int i = 0; i < paymentOptions.Length; i++)
                    {
                        Console.WriteLine(i + " - " + paymentOptions[i]);
                    }

                    int newMethodChoice = Convert.ToInt32(Console.ReadLine());

                    string newMethod = paymentOptions[newMethodChoice];

                    Console.Write("New Account Name: ");
                    string newName = Console.ReadLine();

                    Console.Write("New Account Number / Email: ");
                    string newNumber = Console.ReadLine();

                    service.UpdatePayment(updateIndex, newMethod, newName, newNumber);

                    Console.WriteLine("Payment Updated!");
                    Console.ReadKey();
                    break;

                case 4:

                    Console.Write("Enter Payment Index: ");
                    int deleteIndex = Convert.ToInt32(Console.ReadLine());

                    service.DeletePayment(deleteIndex);

                    Console.WriteLine("Payment Deleted");
                    Console.ReadKey();
                    break;

                case 5:

                    Console.Write("Name: ");
                    string shipName = Console.ReadLine();

                    Console.Write("Address: ");
                    string address = Console.ReadLine();

                    service.AddShipping(shipName, address);

                    Console.WriteLine("Shipping Added");
                    Console.ReadKey();
                    break;

                case 6:

                    var shippings = service.ViewShipping();

                    Console.WriteLine("\nSHIPPING LIST");

                    for (int i = 0; i < shippings.Count; i++)
                    {
                        Console.WriteLine(i + " | " +
                        shippings[i].Name + " | " +
                        shippings[i].Address);
                    }

                    Console.ReadKey();
                    break;

                case 7:

                    var updateShipping = service.ViewShipping();

                    for (int i = 0; i < updateShipping.Count; i++)
                    {
                        Console.WriteLine(i + " | " +
                        updateShipping[i].Name + " | " +
                        updateShipping[i].Address);
                    }

                    Console.Write("\nEnter index to update: ");
                    int shipIndex = Convert.ToInt32(Console.ReadLine());

                    Console.Write("New Name: ");
                    string newShipName = Console.ReadLine();

                    Console.Write("New Address: ");
                    string newAddress = Console.ReadLine();

                    service.UpdateShipping(shipIndex, newShipName, newAddress);

                    Console.WriteLine("Shipping Updated");
                    Console.ReadKey();
                    break;

                case 8:

                    Console.Write("Enter Shipping Index: ");
                    int deleteShip = Convert.ToInt32(Console.ReadLine());

                    service.DeleteShipping(deleteShip);

                    Console.WriteLine("Shipping Deleted");
                    Console.ReadKey();
                    break;

                case 9:
                    return;
            }
        }
    }
}

