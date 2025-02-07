using Microsoft.EntityFrameworkCore;
using SharpBarberAPI.Models;

namespace SharpBarberAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Barber> Barbers { get; set; }
    }
}