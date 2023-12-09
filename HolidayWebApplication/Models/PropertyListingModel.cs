using DomainLayer.Entities;

namespace WebApplicationLayer.Models
{
    public class PropertyListingModel
    {
        public PropertyListingModel()
        {
        }

        public PropertyListingModel(Property property)
        {
            Id = property.Id;
            Name = property.Name;
            Blurb = property.Blurb;
            Location = property.Location;
            NumberOfBedrooms = property.NumberOfBedrooms;
            CostPerNight = property.CostPerNight;
            Images = property.Images.Select(i => i.ImageUrl);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Blurb { get; set; }
        public string Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal CostPerNight { get; set; }
        public IEnumerable<string> Images { get; set; } = new List<string>();
    }
}
