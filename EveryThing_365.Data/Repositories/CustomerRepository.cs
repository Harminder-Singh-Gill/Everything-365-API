using Everything_365.Data.Custom_Models;
using Everything_365.Data.Models;
using Everything_365.Data.Database_Connection;
using Everything_365.Data.DataContext;
using Everything_365.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Repositories
{
    public class CustomerRepository : ICustomerInterface
    {
        private SqlCommand? Cmd { get; set; }

        public string AddNewCustomer(CustomerCustom customer)
        {
            try
            {
                if (customer is null || customer.ToString() == "{}")
                {
                    return "";
                }
                Cmd = new SqlCommand();
                Cmd.Parameters.Add("@first_name", SqlDbType.VarChar).Value = customer.FirstName;
                Cmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = customer.LastName;
                Cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = customer.Password;
                Cmd.Parameters.Add("@email_address", SqlDbType.VarChar).Value = customer.EmailAddress;
                Cmd.Parameters.Add("@phone_number", SqlDbType.VarChar).Value = customer.PhoneNumber;
                Cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = customer.CreatedAt;
                DataTable dataTable = ClsDbConnection.GetDataTable("AddCustomer", Cmd);
                if(dataTable.Rows.Count < 0)
                {
                    return "";
                }
                customer.CustomerId = Convert.ToInt32(dataTable.Rows[0]["customer_id"].ToString());
                Cmd = new SqlCommand();
                if(customer.Address is null || customer.Address.Count < 0)
                {
                    return ""; 
                }
                foreach(var customerAddress in customer.Address)
                {
                    Cmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = customer.CustomerId;
                    Cmd.Parameters.Add("@address_line1", SqlDbType.VarChar).Value = customerAddress.AddressLine1;
                    Cmd.Parameters.Add("@address_line2", SqlDbType.VarChar).Value = customerAddress.AddressLine2;
                    Cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = customerAddress.City;
                    Cmd.Parameters.Add("@postal_code", SqlDbType.VarChar).Value = customerAddress.PostalCode;
                    Cmd.Parameters.Add("@country_id", SqlDbType.Int).Value = customerAddress.CountryId;
                    Cmd.Parameters.Add("@is_default", SqlDbType.Bit).Value = customerAddress.IsDefault;
                    dataTable = ClsDbConnection.GetDataTable("AddCustomerAddress", Cmd);
                }
                Cmd = new SqlCommand();
                Cmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = customer.CustomerId;
                dataTable = ClsDbConnection.GetDataTable("AddCustomerCart", Cmd);

                return "Added new Customer Successfuly";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer GetCustomerDetailsById(EveryThing365DbContext context, int CustomerId)
        {
            Customer customers = new Customer();
            if (context is null || CustomerId == 0)
            {
                return customers;
            }
            customers = context.Customers.Find(CustomerId) ?? new Customer();
            if (customers.ToString() != "{}")
            {
                customers.CustomerAddresses = context.CustomerAddresses.Where
                    (c =>  c.CustomerId == CustomerId).ToList() 
                    ?? new List<CustomerAddress>();
                return customers;
            }
            return customers;
        }
    }
}
