using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ADO_Approach_
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD c = new CRUD();

            Customer c1 = new Customer();
            //Console.Write("Enter CustomerId");
            //c1.CustomerId=int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name:");
            c1.Name = Console.ReadLine();
            Console.Write("Enter Customer Email:");
            c1.Email = Console.ReadLine();
            string message = c.AddCustomer(c1);
            Console.WriteLine(message);
            Console.WriteLine("========================");
            Console.WriteLine("Customer List");
            PrintList();

            Console.WriteLine("Enter the CustomerId for delete:");
            int  CustomerId=int.Parse(Console.ReadLine());
            string msg = c.DeleteCustomer(CustomerId);
            Console.WriteLine(msg);
            Console.WriteLine("========================");
            PrintList();

            Customer c2= new Customer();
            Console.WriteLine("Enter the CustomerId to Update:");
            c2.CustomerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name of the Customer:");
            c2.Name= Console.ReadLine();
            Console.WriteLine("Enter the Email of the Customer");
            c2.Email= Console.ReadLine();
            string s=c.UpdateCustomer(c2);
            Console.WriteLine(s);
            Console.WriteLine("========================");
            PrintList();
        }
        public static void PrintList()
        {
            CRUD c=new CRUD();  
            List<Customer> customerlist = c.GetCustomers();
            foreach (Customer customer in customerlist)
            {
                Console.WriteLine($" CustomerId: {customer.CustomerId} | Name: {customer.Name} | Email: {customer.Email}");
            }

        }

            //List<Product> products = c.GetProducts();
            //foreach (Product product in products)
            //{
            //    Console.WriteLine($" ProductId: {product.ProductId} | Name: {product.Name} | Price: {product.Price} | Stock: {product.StockQuantity}");
            //}

        }
    }
