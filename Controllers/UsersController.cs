using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular7CRUDAPI;
using Microsoft.AspNetCore.Cors;

namespace Angular7CRUDAPI.Controllers
{
    [Route("api/Angular7CRUDAPI")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Angular7CRUDContext _context;

        public UsersController(Angular7CRUDContext context)
        {
            _context = context;
        }
        //GET: 
        [HttpGet("validate/username={username}&password={password}")]
        [EnableCors("AllowAllHeaders")]
        public bool ValidateUser(string username,string password)
        {
            User myUser = _context.User.FirstOrDefault
               (u => u.Username.Equals(username) && u.Password.Equals(password));
            if (myUser != null)
            {
                return true;
            }
            else    //User was not found
            {
                return false;
            }
        }
        //POST: 
        [HttpPost("validate")]
        [EnableCors("AllowAllHeaders")]
        public bool ValidateUser(User user)
        {
            User myUser = _context.User.FirstOrDefault
               (u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
            if (myUser != null)
            {
                return true;
            }
            else    //User was not found
            {
                return false;
            }
        }

        // GET: api/Users
        [HttpGet]
        [EnableCors("AllowAllHeaders")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]      
        public async Task<IActionResult> PutUser(int id, [FromBody]User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
