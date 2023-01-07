using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using Services.ServicesForModels;

namespace Global_Superstore_ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        public CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get-all-customers")]
        public IActionResult GetAllCustomers()
        {
            var allCustomers = _customerService.GetAllCustomers();
            return Ok(allCustomers);
        }
        [HttpGet("get-customers-by-id/{id}")]
        public IActionResult GetCustomersById(int id)
        {
            var customers = _customerService.GetCustomersById(id);
            return Ok(customers);
        }


        [HttpPost("add-customers")]
        public IActionResult AddCustomer([FromBody]Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }


        [HttpPut("update-customer-by-id/{id}")]
        public IActionResult UpdateCustomerById(int id, [FromBody] CustomerVM customer)
        {
            var updateCustomer = _customerService.UpdateCustomersById(id, customer);
            return Ok(updateCustomer);
        }


        [HttpDelete("delete-customers-by-id/{id}")]
        public IActionResult DeleteCustomerById(int id)
        {
            _customerService.DeleteCustomerById(id);
            return Ok();
        }
    }
}
