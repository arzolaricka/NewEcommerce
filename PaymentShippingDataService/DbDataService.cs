using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PaymentShippingModel;

namespace PaymentShippingDataService
{
    public class DbDataService : IPaymentShippingDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=PaymentShippingDB;Integrated Security=True;TrustServerCertificate=True;";


        public void AddPayment(Payment payment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Payment (Method, AccountName, AccountNumber) VALUES (@Method,@Name,@Number)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Method", payment.Method);
                    cmd.Parameters.AddWithValue("@Name", payment.AccountName);
                    cmd.Parameters.AddWithValue("@Number", payment.AccountNumber);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Payment added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (AddPayment): " + ex.Message);
            }
        }

        public List<Payment> GetPayments()
        {
            List<Payment> list = new List<Payment>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "SELECT Id, Method, AccountName, AccountNumber FROM Payment", conn);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Payment(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3)
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (GetPayments): " + ex.Message);
            }

            return list;
        }

        public void UpdatePayment(int id, Payment payment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Payment SET Method=@Method, AccountName=@Name, AccountNumber=@Number WHERE Id=@Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Method", payment.Method);
                    cmd.Parameters.AddWithValue("@Name", payment.AccountName);
                    cmd.Parameters.AddWithValue("@Number", payment.AccountNumber);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Payment updated!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (UpdatePayment): " + ex.Message);
            }
        }

        public void DeletePayment(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Payment WHERE Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Payment deleted!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (DeletePayment): " + ex.Message);
            }
        }


        public void AddShipping(Shipping shipping)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Shipping (Name, Address) VALUES (@Name,@Address)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Name", shipping.Name);
                    cmd.Parameters.AddWithValue("@Address", shipping.Address);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Shipping added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (AddShipping): " + ex.Message);
            }
        }

        public List<Shipping> GetShippings()
        {
            List<Shipping> list = new List<Shipping>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "SELECT Id, Name, Address FROM Shipping", conn);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Shipping(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (GetShipping): " + ex.Message);
            }

            return list;
        }

        public void UpdateShipping(int id, Shipping shipping)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Shipping SET Name=@Name, Address=@Address WHERE Id=@Id", conn);

                    cmd.Parameters.AddWithValue("@Name", shipping.Name);
                    cmd.Parameters.AddWithValue("@Address", shipping.Address);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Shipping updated!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (UpdateShipping): " + ex.Message);
            }
        }

        public void DeleteShipping(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Shipping WHERE Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Shipping deleted!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR (DeleteShipping): " + ex.Message);
            }
        }
    }
}