using CustomerBusinessLayer;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace CustomerDataAccessLayer
{
    internal class customerDetails
    {
        public static void Main(String[] args)
        {

            Console.WriteLine("Customer Management System");
            Console.WriteLine("Add Customer Details");

            Console.WriteLine("Add Customer ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Add Customer Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Add City:");
            string city = Console.ReadLine();

            Console.WriteLine("Add Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Add Phone Number:");
            string phone = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Add Pincode:");
            int pincode = Convert.ToInt32(Console.ReadLine());

            string cs = "data source =.; database = Assignment3MVC; integrated security= SSPI";
                SqlConnection con = new SqlConnection(cs);

            string query = string.Format("insert into Customer values({0}, '{1}', '{2}', {3}, '{4}', {5})",
                                          id, name, city, age, phone, pincode);

            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            int n = cmd.ExecuteNonQuery();

            Console.WriteLine($"{n} row inserted successfully");
            con.Close();

        }
    }
}
