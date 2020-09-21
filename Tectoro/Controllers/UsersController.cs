using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tectoro.Models.DB;

namespace Tectoro.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TectoroContext _context;

        public UsersController(TectoroContext context)
        {
            _context = context;
        }

        [Route("GetUsers")]
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users;
        }


        [Route("GetUserById")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }


        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] Users users)
        {
            if (users.UserId == 0)
            {
                return BadRequest();
            }
            if (!UsersExists(users.UserId))
            {
                return NotFound();
            }

            _context.Entry(users).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserById", new { id = users.UserId }, users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }


        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserById", new { id = users.UserId }, users);
        }


        [Route("DeleteUser")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return Ok(users);
        }

    }
}