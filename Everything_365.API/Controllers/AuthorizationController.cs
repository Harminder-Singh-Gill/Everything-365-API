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
        public string CheckCustomerEmail(string email)
        {
            AuthInterface = new AuthorizationRepository();
            return AuthInterface.CheckCustomerEmail(Context, email);
        }

        [HttpPost]
        public string CheckCustomerPhoneNumber(string phoneNumber)
        {
            AuthInterface = new AuthorizationRepository();
            return AuthInterface.CheckCustomerPhoneNumber(Context, phoneNumber);
        }

        [HttpPost]
        public string CustomerLogin(string email, string password)
        {
            AuthInterface = new AuthorizationRepository();
            return AuthInterface.CustomerLogin(Context, email, password);
        }

    }
}
