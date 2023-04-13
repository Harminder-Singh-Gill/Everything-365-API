using Everything_365.Data.DataContext;
using Everything_365.Data.Interfaces;
using Everything_365.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Repositories
{
    public class AuthorizationRepository : IAuthorizationInterface
    {
        public string CheckCustomerEmail(EveryThing365DbContext context, string email)
        {
            Customer customer = new Customer();
            customer = context.Customers.Where(c => c.EmailAddress == email).FirstOrDefault() ?? new Customer();
            if(customer.CustomerId == 0 || customer.EmailAddress == null)
            {
                return "";
            }
            if(customer.EmailAddress.ToLower() != email.ToLower())
            {
                return "";
            }
            return "Email address already exits";
        }

        public string CheckCustomerPhoneNumber(EveryThing365DbContext context, string phoneNumber)
        {
            Customer customer = new Customer();
            customer = context.Customers.Where(c => c.PhoneNumber == phoneNumber).FirstOrDefault() ?? new Customer();
            if (customer.CustomerId == 0 || customer.PhoneNumber == null)
            {
                return "";
            }
            if (customer.PhoneNumber.ToLower() != phoneNumber.ToLower())
            {
                return "";
            }
            return "Phone number already exits";
        }

        public string CustomerLogin(EveryThing365DbContext context, string email, string password)
        {
            Customer customer = new Customer();

            customer = context.Customers.Where(c => c.EmailAddress == email).FirstOrDefault() ?? new Customer();

            if (customer.CustomerId == 0 || customer.EmailAddress == null || customer.Password == null)
            {
                return "Invalid Email";
            }
            if (customer.EmailAddress.ToLower() != email.ToLower())
            {
                return "Invalid Email";
            }
            if(customer.Password != password)
            {
                return "Invalid Password";
            }
            return "Token";

        }
    }
}
