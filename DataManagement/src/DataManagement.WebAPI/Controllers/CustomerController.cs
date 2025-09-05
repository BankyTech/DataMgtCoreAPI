using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customers = _customerRepository.Get();
                return Ok(customers);
            }
            catch (Exception)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while retrieving customers");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Customer ID must be greater than 0");
                }

                var customer = _customerRepository.Get(id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found");
                }

                return Ok(customer);
            }
            catch (Exception)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while retrieving the customer");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer data is required");
                }

                if (string.IsNullOrEmpty(customer.CustomerName))
                {
                    return BadRequest("Customer name is required");
                }

                _customerRepository.Add(customer);
                return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
            }
            catch (Exception)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while creating the customer");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Customer ID must be greater than 0");
                }

                if (customer == null)
                {
                    return BadRequest("Customer data is required");
                }

                if (customer.CustomerId != id)
                {
                    return BadRequest("Customer ID in URL does not match Customer ID in body");
                }

                if (string.IsNullOrEmpty(customer.CustomerName))
                {
                    return BadRequest("Customer name is required");
                }

                _customerRepository.Update(customer);
                return NoContent();
            }
            catch (Exception)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while updating the customer");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Customer ID must be greater than 0");
                }

                _customerRepository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while deleting the customer");
            }
        }
    }
}
