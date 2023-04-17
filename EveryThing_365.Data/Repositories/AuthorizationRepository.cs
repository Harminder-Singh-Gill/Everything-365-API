using Everything_365.Data.Custom_Models;
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
        public string CheckCustomerEmail(EveryThing365DbContext context, CheckCustomerEmail customer)
        {
            Customer checkCustomer = new Customer();
            if(customer.EmailAddress == null)
            {
                return "empty input field";
            }
            checkCustomer = context.Customers.Where(c => c.EmailAddress == customer.EmailAddress)
                .FirstOrDefault() ?? new Customer();
            if(checkCustomer.CustomerId == 0 || checkCustomer.EmailAddress == null)
            {
                return "";
            }
            if(checkCustomer.EmailAddress.ToLower() != customer.EmailAddress.ToLower())
            {
                return "";
            }
            return "Email address already exits";
        }

        public string CheckCustomerPhoneNumber(EveryThing365DbContext context, CheckCustomerPhone customer)
        {
            Customer checkCustomer = new Customer();
            if (customer.PhoneNumber == null)
            {
                return "empty input field";
            }
            checkCustomer = context.Customers.Where(c => c.PhoneNumber == customer.PhoneNumber)
                .FirstOrDefault() ?? new Customer();
            if (checkCustomer.CustomerId == 0 || checkCustomer.PhoneNumber == null)
            {
                return "";
            }
            if (checkCustomer.PhoneNumber.ToLower() != customer.PhoneNumber.ToLower())
            {
                return "";
            }
            return "Phone number already exits";
        }

        public string CustomerLogin(EveryThing365DbContext context, CustomerLogin customerLoginDetails)
        {
            Customer customer = new Customer();
            if(customerLoginDetails.EmailAddress == null || customerLoginDetails.Password == null)
            {
                return "Empty input field";
            }
            customer = context.Customers.Where(c => c.EmailAddress == customerLoginDetails.EmailAddress)
                .FirstOrDefault() ?? new Customer();

            if (customer.CustomerId == 0 || customer.EmailAddress == null || customer.Password == null)
            {
                return "Invalid Email";
            }
            if (customer.EmailAddress != customerLoginDetails.EmailAddress)
            {
                return "Invalid Email";
            }
            if(customer.Password != customerLoginDetails.Password)
            {
                return "Invalid Password";
            }
            return "Token";
        }
    }
}
