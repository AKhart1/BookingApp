using DomainLayer.Entities;

namespace WebApplicationLayer.Models
{
    public class PropertyDetailsModel : PropertyListingModel
    {
        public PropertyDetailsModel()
        {
        }

        public PropertyDetailsModel(Property property)
            : base(property)
        {
            Description = property.Description;
            BookedStartDates = property.BookedNights
                .Select(n => n.Night.AddDays(-1))
                .ToList();
            BookedEndDates = property.BookedNights
                .Select(n => n.Night)
                .ToList();
        }

        public string? Description { get; set; }
        public List<DateTime> BookedStartDates { get; set; } = new();
        public List<DateTime> BookedEndDates { get; set; } = new();

        public Property ToPropertyModel()
        {
            return new Property
            {
                Name = Name,
                Description = Description,
                Blurb = Blurb,
                Location = Location,
                NumberOfBedrooms = NumberOfBedrooms,
                CostPerNight = CostPerNight
            };
        }
    }
}
