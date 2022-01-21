using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Db;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private EdModel _efModel;

        public UserController(EdModel model)
        {
            _efModel = model;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers() {
            return await _efModel.users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            if (User == null)
                return NotFound();

            return await _efModel.users.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _efModel.users.Add(user);
            await _efModel.SaveChangesAsync();

            return CreatedAtAction(nameof(PostUser), new { id = user.UserID }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) 
        {
            var user = await _efModel.users.FindAsync(id);
            if (user == null)
                return NotFound();
            _efModel.users.Remove(user);
            await _efModel.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user) 
        {
            if (id != user.UserID)
                return BadRequest();

            _efModel.Entry(user).State = EntityState.Modified;
            try
            {
                await _efModel.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
