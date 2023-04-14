using Everything_365.Data.Custom_Models;
using Everything_365.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Interfaces
{
    public interface IAuthorizationInterface
    {
        public string CheckCustomerEmail(EveryThing365DbContext context, CheckCustomerEmail customer);
        public string CheckCustomerPhoneNumber(EveryThing365DbContext context, CheckCustomerPhone customer);
        public string CustomerLogin(EveryThing365DbContext context, CustomerLogin loginDetails);
    }
}
