using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities
{
    public class Property
    {
        public int Id { get; set; }

        [MaxLength(256)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }

        [MaxLength(256)]
        public string? Blurb { get; set; }

        [MaxLength(256)]
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        public int NumberOfBedrooms { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPerNight { get; set; }

        public List<BookedNight> BookedNights { get; set; } = new();

        public List<PropertyImage> Images { get; set; } = new();
    }
}
