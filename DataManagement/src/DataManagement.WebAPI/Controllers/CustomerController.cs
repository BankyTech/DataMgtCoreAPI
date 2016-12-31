using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
             return _customerRepository.Get();
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            _customerRepository.Add(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer customer)
        {
            _customerRepository.Update(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}
