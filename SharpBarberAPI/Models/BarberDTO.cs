using System.ComponentModel.DataAnnotations;

namespace SharpBarberAPI.Models
{
    public class BarberDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<string> AvailableHours { get; set; } = new List<string>();
        public List<string> Services { get; set; } = new List<string>();
    }
}
