using Microsoft.EntityFrameworkCore;
using SharpBarberAPI.Models;

namespace SharpBarberAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
