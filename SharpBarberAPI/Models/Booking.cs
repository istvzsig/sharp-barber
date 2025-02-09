using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SharpBarberAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;

        public int BarberId { get; set; }
        [ForeignKey("BarberId")]
        public Barber? Barber { get; set; }
    }
}
