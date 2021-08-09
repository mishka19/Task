using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;
using Task.Repositories;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.Get();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomers(int id)
        {
            return _customerRepository.Get(id);
        }

        [HttpPost]

        public ActionResult<Customer> PostCustomers([FromBody] Customer customer)
        {
          var newCustomer= _customerRepository.Create(customer);
            return CreatedAtAction(nameof(GetCustomers), new { id = newCustomer.CustomerId }, newCustomer);
        }

        [HttpPut]

        public ActionResult PutCustmers(int id,[FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            _customerRepository.Update(customer);
             return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerToDelete = _customerRepository.Get(id);
            if (customerToDelete == null)
            {
                return NotFound();
            }
            _customerRepository.Delete(customerToDelete.CustomerId);
            return NoContent();
        }
    }
}
