using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SharpBarberAPI.Models
{
    public class Barber
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public List<string> AvailableHours { get; set; } = new List<string>();
        public List<string> Services { get; set; } = new List<string>();
    }
}
