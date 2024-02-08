using BusBookingWebApi.BusinessObjects;
using BusBookingWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BusBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : Controller
    {
        private readonly DataContext _context;

        public PassengerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
            if (_context.buses == null)
            {
                return NotFound();
            }
            return await _context.Passengers.Select(x => new Passenger
            {
                Gender = x.Gender,
                PassengerContact = x.PassengerContact,
                PassengerMember = x.PassengerMember,
                PassengerNonMember = x.PassengerNonMember,
                PassengerEmail = x.PassengerEmail,
                Tickets = x.Tickets,
                Name = x.Name
            }).ToListAsync();
        }
        [HttpPost]
        public ActionResult CreatePassenger(PassengerDTO passenger)
        {
            if (_context.buses == null)
            {
                return NoContent();

            }
            var rnn = new Random();
            var passngr = new Passenger()
            {
                PaId = rnn.Next(),
                Name = passenger.Name,
                Gender = passenger.Gender,
                Password = ComputeSHA256(passenger.Password),
                PassengerEmail = new PassengerEmail()
                {
                    Emails = passenger.PassengerEmail.Emails
                }
            };
            _context.Passengers.Add(passngr);
            _context.SaveChanges();

            if (passenger.IsMember)
            {
                _context.PassengerMembers.Add(new PassengerMember()
                {
                    ExpDate = DateTime.Now,
                    MId = passngr.PaId,
                    Cid = passenger.cId
                });

            }
            else
            {
                _context.PassengerNonMembers.Add(new PassengerNonMember()
                {
                    Nmid = passngr.PaId
                });
            }
            _context.SaveChanges();
            return Created("created", new { passenger });
        }

        static string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
    }
}
