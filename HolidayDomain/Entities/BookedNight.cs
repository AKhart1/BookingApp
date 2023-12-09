using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class BookedNight
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }

        [DataType(DataType.Date)]
        public DateTime Night { get; set; }
    }
}
