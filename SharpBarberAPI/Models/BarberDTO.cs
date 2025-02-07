using System.ComponentModel.DataAnnotations;

namespace SharpBarberAPI.Models
{
    public class BarberDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}