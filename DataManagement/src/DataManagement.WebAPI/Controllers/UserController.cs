using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
       
        public UserController(IUserManager userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userManager.GetAllUser();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while retrieving users");
            }
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("User ID must be greater than 0");
                }

                var user = _userManager.GetUserById(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while retrieving the user");
            }
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is required");
                }

                if (string.IsNullOrEmpty(user.UserName))
                {
                    return BadRequest("User name is required");
                }

                var result = _userManager.AddUser(user);
                if (result)
                {
                    return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
                }

                return StatusCode(500, "Failed to create user");
            }
            catch (Exception ex)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while creating the user");
            }
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("User ID must be greater than 0");
                }

                if (user == null)
                {
                    return BadRequest("User data is required");
                }

                if (user.UserId != id)
                {
                    return BadRequest("User ID in URL does not match User ID in body");
                }

                if (string.IsNullOrEmpty(user.UserName))
                {
                    return BadRequest("User name is required");
                }

                var result = _userManager.UpdateUser(user);
                if (result)
                {
                    return NoContent();
                }

                return StatusCode(500, "Failed to update user");
            }
            catch (Exception ex)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while updating the user");
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("User ID must be greater than 0");
                }

                var result = _userManager.DeleteUser(id);
                if (result)
                {
                    return NoContent();
                }

                return StatusCode(500, "Failed to delete user");
            }
            catch (Exception ex)
            {
                // In a real application, use proper logging here
                return StatusCode(500, "An error occurred while deleting the user");
            }
        }
    }
}
