using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatFormCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}