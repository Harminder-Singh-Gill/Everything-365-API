using Everything_365.Data.Custom_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Interfaces
{
    public interface ICustomerInterface
    {
        public string AddNewCustomer(Customer customer);
    }
}
