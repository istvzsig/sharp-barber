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
    public class BarbersController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // POST: api/barbers
        [HttpPost]
        public async Task<ActionResult<Barber>> CreateBarber([FromBody] Barber barber)
        {
            if (barber == null)
            {
                return BadRequest("Invalid barber data.");
            }

            _context.Barbers.Add(barber);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBarber), new { id = barber.Id }, barber);
        }

        // GET: api/barbers
        [HttpGet]
        public async Task<ActionResult<List<Barber>>> GetBarbers()
        {
            var barbers = await _context.Barbers.ToListAsync();
            return Ok(barbers);
        }

        // GET: api/barbers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Barber>> GetBarber(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
            {
                return NotFound(new { message = "Barber not found." });
            }
            return Ok(barber);
        }

        // PUT: api/barbers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarber(int id, [FromBody] Barber barber)
        {
            if (id != barber.Id)
            {
                return BadRequest("Barber ID mismatch.");
            }

            _context.Entry(barber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberExists(id))
                {
                    return NotFound(new { message = "Barber not found." });
                }
                throw;
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/barbers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
            {
                return NotFound(new { message = "Barber not found." });
            }

            _context.Barbers.Remove(barber);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        private bool BarberExists(int id) => _context.Barbers.Any(e => e.Id == id);
    }
}
