using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingWebApi.BusinessObjects;
using BusBookingWebApi.Data;

namespace BusBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : Controller
    {
        private readonly DataContext _context;

        public BusesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuDTO>>> GetServices()
        {
            if (_context.buses == null)
            {
                return NotFound();
            }
            return await _context.buses.Select(x => new BuDTO
            {
                BId = x.BId,
                NoPlate = x.NoPlate,
                Color = x.Color,
                Type = x.Type,
                BusRoutes = x.BusRoutes,
                Ticket = x.BusRoutes.Select(x => x.RIdNavigation.Tickets).FirstOrDefault(),
            }).ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BuDTO>> GetServices(int id)
        {
            if (_context.buses == null)
            {
                return NotFound();
            }
            return await _context.buses.Where(y => y.BId == id).Select(x => new BuDTO
            {
                BId = x.BId,
                NoPlate = x.NoPlate,
                Color = x.Color,
                Type = x.Type,
                BusRoutes = x.BusRoutes,
                Ticket = x.BusRoutes.Where(b => b.BId == x.BId).Select(x => x.RIdNavigation.Tickets).FirstOrDefault(),
            }).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("driver")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            return await _context.Drivers.Select(x => new Driver
            {
                DId = x.DId,
                Name = x.Address,
                Address = x.Address,
                DriverContact = x.DriverContact,
                DriverEmail = x.DriverEmail,
                DriverFullTime = x.DriverFullTime,
                Lisences = x.Lisences,
                BIds = x.BIds
            }).ToListAsync();
        }

        [HttpGet]
        [Route("tickets/{pId}")]
        public async Task<ActionResult<IEnumerable<TicketResponseDTO>>> GetTickets(int pId)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            return await _context.Tickets.Where(t => t.PId == pId).Select(x => new TicketResponseDTO
            {
                PId = x.PId,
                RId = x.RId,
                Location = x.RIdNavigation.Location,
                Amount = x.Amount,
                Date = x.Date
            }).ToListAsync();
        }

        [HttpPost]
        [Route("bookticket")]
        public async Task<IActionResult> BookTicket(TicketDTO ticket)
        {
            if (_context.buses == null)
            {
                return NoContent();

            }
            var rann = new Random();
            var addTicket = new Ticket()
            {
                Tid = rann.Next(),
                TNum = ticket.TNum,
                Amount = ticket.Amount,
                RId = ticket.RId,
                PId = ticket.PId,
                Date = DateTime.Now
            };

            _context.Tickets.Add(addTicket);
            _context.SaveChanges();

            return Created("created", new { ticket });
        }

        [HttpPost]
        public async Task<IActionResult> AddBus(Bu bus)
        {
            if (_context.buses == null)
            {
                return NoContent();

            }
            _context.buses.Add(bus);

            return Created("created", new { bus});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Bu bus)
        {
            if (id != bus.BId)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (_context.buses == null)
            {
                return NotFound();
            }
            var company = await _context.buses.Where(x => x.BId == id).Select(x => new Bu
            {
                BId = x.BId,
                Color = x.Color,
                Type = x.Type,
                NoPlate = x.NoPlate
            }).FirstOrDefaultAsync();
            if (company == null)
            {
                return NotFound();
            }

            _context.buses.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(string noPlate)
        {
            return (_context.buses?.Any(e => e.NoPlate == noPlate)).GetValueOrDefault();
        }
    }
}
