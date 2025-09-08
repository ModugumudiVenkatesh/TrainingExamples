using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ADO_Approach_
{
    public class CRUD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        public List<Customer> GetCustomers()
        {
            List<Customer> customerlist = new List<Customer>();
            SqlCommand cmd = new SqlCommand("select * from customers", con);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            foreach(DataRow drow in dt.Rows)
            {
                Customer customer = new Customer()
                {
                    CustomerId = int.Parse(drow["CustomerId"].ToString()),
                    Name = drow["Name"].ToString(),
                    Email = drow["email"].ToString(),
                    Password = drow["password"].ToString(),
                };
                customerlist.Add(customer);
            }
        return customerlist;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow drow in dt.Rows)
            {
                Product product = new Product()
                {
                    ProductId = int.Parse(drow["ProductId"].ToString()),
                    Name = drow["Name"].ToString(),
                    Description = drow["Description"].ToString(),
                    Price = decimal.Parse(drow["Price"].ToString()),
                    StockQuantity = int.Parse(drow["StockQuantity"].ToString())
                };
                products.Add(product);
            }

            return products;
        }
        
        public string AddCustomer(Customer customer)
        {
            SqlCommand sqlCommand = new SqlCommand(
            "insert into customers (Name, Email, Password) values('" + customer.Name + "', '" + customer.Email + "', '" + customer.Password + "')", con);

            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return "Successfully Inserted a Record";
            }
            catch (Exception ex)
            {
                return "Customer insert failed:" +ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteCustomer(int CustomerId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @Id", con);
                cmd.Parameters.AddWithValue("@Id", CustomerId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return "Customer deleted successfully";
                else
                    return "No category found with the given ID.";
            }
            catch (Exception ex)
            {
                return "Customer delete failed with error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

        }

        public string UpdateCustomer(Customer customer)
        {
            SqlCommand sqlCommand = new SqlCommand(
                "UPDATE Customers SET Name = '" + customer.Name + "', Email = '" + customer.Email + "', Password = '" + customer.Password + "' WHERE CustomerId = " + customer.CustomerId, con);
            try
            {
                con.Open();
                sqlCommand.ExecuteNonQuery();
                return "Customer Updated Successfully ";
            }
            catch (Exception ex)
            {
                return "Customer Update failed:" + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
