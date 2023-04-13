using Everything_365.Data.Custom_Models;
using Everything_365.Data.DataContext;
using Everything_365.Data.Interfaces;
using Everything_365.Data.Models;
using Everything_365.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Everything_365.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerInterface? CustomerInterface { get; set; } 
        private EveryThing365DbContext Context { get; set; }

        public CustomerController(EveryThing365DbContext context)
        {
            Context = context;
        }

        [HttpPost]
        public string AddNewCustomer(CustomerCustom customer)
        {
            CustomerInterface = new CustomerRepository();
            return CustomerInterface.AddNewCustomer(customer);
        }

        [HttpGet]
        public Customer GetCustomerDetailsById(int customerId)
        {
            CustomerInterface = new CustomerRepository();
            return CustomerInterface.GetCustomerDetailsById(Context, customerId);
        }
    }
}
