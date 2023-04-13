using Everything_365.Data.Custom_Models;
using Everything_365.Data.Interfaces;
using Everything_365.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Everything_365.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerInterface? CustomerInterface { get; set; } 

        [HttpPost]
        public string AddNewCustomer(Customer customer)
        {
            CustomerInterface = new CustomerRepository();
            return CustomerInterface.AddNewCustomer(customer);
        }
    }
}
