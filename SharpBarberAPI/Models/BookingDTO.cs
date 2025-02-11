using System;
using System.ComponentModel.DataAnnotations;

namespace SharpBarberAPI.Models
{
    public class BookingDTO
    {
        public int Id { get; set; }

        [Required]
        public int BarberId { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string Service { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }
    }
}
