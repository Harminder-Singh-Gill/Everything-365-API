using Everything_365.Data.Custom_Models;
using Everything_365.Data.DataContext;
using Everything_365.Data.Interfaces;
using Everything_365.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Everything_365.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthorizationInterface? AuthInterface { get; set; }
        private EveryThing365DbContext Context { get; set; }

        public AuthorizationController(EveryThing365DbContext context)
        {
            Context = context;
        }

        [HttpPost]
        public string CheckCustomerEmail(CheckCustomerEmail customer)
        {
            AuthInterface = new AuthorizationRepository();
            return AuthInterface.CheckCustomerEmail(Context, customer);
        }

        [HttpPost]
        public string CheckCustomerPhoneNumber(CheckCustomerPhone customer)
        {
            AuthInterface = new AuthorizationRepository();
            return AuthInterface.CheckCustomerPhoneNumber(Context, customer);
        }

        [HttpPost]
        public string CustomerLogin(CustomerLogin loginDetails)
        {
            AuthInterface = new AuthorizationRepository();
            return AuthInterface.CustomerLogin(Context, loginDetails);
        }

    }
}
