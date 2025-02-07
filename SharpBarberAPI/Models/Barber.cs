using System.ComponentModel.DataAnnotations;

namespace SharpBarberAPI.Models
{
    public class Barber
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}