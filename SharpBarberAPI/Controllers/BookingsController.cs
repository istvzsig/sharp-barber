using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpBarberAPI.Data;
using SharpBarberAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBarberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null)
            {
                return BadRequest("Invalid booking data.");
            }

            var booking = new Booking
            {
                BarberId = bookingDTO.BarberId,
                CustomerName = bookingDTO.CustomerName,
                Service = bookingDTO.Service,
                DateTime = bookingDTO.DateTime
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return Ok(bookings);
        }

        // GET: api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound(new { message = "Booking not found." });
            }
            return Ok(booking);
        }

        // PUT: api/bookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDTO bookingDTO)
        {
            if (id != bookingDTO.Id)
            {
                return BadRequest("Booking ID mismatch.");
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound(new { message = "Booking not found." });
            }

            booking.BarberId = bookingDTO.BarberId;
            booking.CustomerName = bookingDTO.CustomerName;
            booking.Service = bookingDTO.Service;
            booking.DateTime = bookingDTO.DateTime;

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound(new { message = "Booking not found." });
                }
                throw;
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/bookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound(new { message = "Booking not found." });
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        private bool BookingExists(int id) => _context.Bookings.Any(e => e.Id == id);
    }
}
