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
        public string CheckCustomerEmail(EveryThing365DbContext context, string email);
        public string CheckCustomerPhoneNumber(EveryThing365DbContext context, string phoneNumber);
        public string CustomerLogin(EveryThing365DbContext context, string email, string password);
    }
}
