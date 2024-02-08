using BusBookingWebApi.BusinessObjects;
using BusBookingWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly DataContext _context;

        public DriverController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            if (_context.buses == null)
            {
                return NotFound();
            }
            return await _context.Drivers.Select(x => new Driver
            {
                BIds = x.BIds,
                DId = x.DId,
                DriverEmail = x.DriverEmail,
                Address = x.Address,
                Lisences = x.Lisences,
                Name = x.Name,
                DriverContact = x.DriverContact
            }).ToListAsync();
        }

        [HttpPost]
        public ActionResult CreateDriver(Driver driver)
        {
            if (_context.buses == null)
            {
                return NoContent();

            }
            _context.Drivers.Add(driver);

            return Created("created", new { driver });
        }


    }
}
