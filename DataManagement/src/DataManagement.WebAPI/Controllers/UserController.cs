using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserManager _userManager;
       
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userManager.GetAllUser();
            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            //return "value";
            return _userManager.GetUserById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _userManager.AddUser(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            _userManager.UpdateUser(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
