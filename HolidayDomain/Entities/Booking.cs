using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPerNight { get; set; }

        [MaxLength(450)]
        public string? UserId { get; set; }

        [MaxLength(256)]
        [Required(ErrorMessage = "User email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string UserEmail { get; set; }

        [MaxLength(256)]
        [Required(ErrorMessage = "Billing address is required")]
        public string BillingAddress { get; set; }
    }
}
