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
        [StringLength(13, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 13 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "Service description is too long.")]
        public string Service { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }
    }
}
