using Everything_365.Data.Custom_Models;
using Everything_365.Data.DataContext;
using Everything_365.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Interfaces
{
    public interface ICustomerInterface
    {
        public string AddNewCustomer(CustomerCustom customer);
        public Customer GetCustomerDetailsById(EveryThing365DbContext context, int customerId);
       
    }
}
