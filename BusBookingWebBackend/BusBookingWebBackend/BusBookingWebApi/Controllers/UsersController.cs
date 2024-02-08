using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingWebApi.BusinessObjects;
using BusBookingWebApi.Data;
using BusBookingWebApi.Interfaces;

namespace BusBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Identity>>> GetUsers()
        {
            if (_context.Identities == null)
            {
                return NotFound();
            }
            return await _context.Identities.Select(u => new Identity
            {
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Email = u.Email,
                IdentityTypeId = u.IdentityTypeId,
                IdentityId = u.IdentityId,
                Phone = u.Phone,
                IsArchived = u.IsArchived
            }).ToListAsync();
        }

        [HttpGet]
        [Route("Company/{Id}")]
        public async Task<ActionResult<IEnumerable<Identity>>> GetUsersByCompanyId(int Id)
        {
            if (_context.Identities == null)
            {
                return NotFound();
            }
            return await _context.Identities.Where(c => c.IdentityId == Id && c.IdentityTypeId == 3).Select(u => new Identity
            {
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Email = u.Email,
                IdentityTypeId = u.IdentityTypeId,
                IdentityId = u.IdentityId,
                Phone = u.Phone,
            }).ToListAsync();
        }

        [HttpPost]
        [Route("userLogin")]
        public async Task<ActionResult<Passenger>> UserLogin(LoginRequest request)
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            var user = await _context.Passengers.Where(c => c.PassengerEmail.Emails == request.Email && c.Password == request.Password).FirstOrDefaultAsync();
            if(user != null)
            {
                return user;
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Identity>> GetUser(int id)
        {
          if (_context.Identities == null)
          {
              return NotFound();
          }
            var user = await _context.Identities.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Identity user)
        {
            if (id != user.IdentityId)
            {
                return BadRequest();
            }

            var userObj = _context.Identities.Where(u => u.IdentityId == id).FirstOrDefault();

            userObj.Firstname = user.Firstname;
            userObj.Lastname = user.Lastname;
            userObj.Email = user.Email;
            userObj.Phone = user.Phone;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id) && (!UserEmailExists(user.Email)))
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


        [HttpPost]
        [Route("passwordRS")]
        public async Task<IActionResult> ResetUserPasswordRequest(Identity user, string typedEmail)
        {

            if ((!UserEmailExists(typedEmail))) 
            {
                return NotFound();
            }
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();  
            }
            catch (DbUpdateConcurrencyException)
            {
                if ( (!UserExists(user.IdentityId)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            try  
            {
                
            }
            catch (Exception)
            {
                return Problem();
            }


            return NoContent();
        }

        [HttpGet]
        [Route("blockOrUnBlockUser")]
        public async Task<IActionResult> BlockOrUnBlockUser(int userId)
        {
            var user = await _context.Identities.Where(u => u.IdentityId == userId).FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.IsArchived == false)
                {
                    user.IsArchived = true;
                }
                else
                {
                    user.IsArchived = false;
                }

                _context.SaveChanges();

            }


            return NoContent();

        }


        [HttpPost]
        public async Task<ActionResult<Identity>> PostUser(Identity user)
        {
          if (_context.Identities == null)
          {
              return Problem("Entity set 'DataContext.Users'  is null.");
          }
            _context.Identities.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.IdentityId }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Identities == null)
            {
                return NotFound();
            }
            var user = await _context.Identities.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Identities.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Identities?.Any(e => e.IdentityId == id)).GetValueOrDefault();
        }

        private bool UserEmailExists(string email)
        {
            return (_context.Identities?.Any(e => e.Email == email)).GetValueOrDefault();
        }
    }
}
