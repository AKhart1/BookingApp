using DomainLayer.Entities;

namespace DomainLayer.Repositories
{
    public class DummyPropertyRepository
    {
        private readonly List<Property> _properties = new()
        {
            new () {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350,
                Description = "Very comfortable and nice for a relaxing holiday",
                BookedNights = new()
            },
            new () {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730,
                Description = "Very presentable and attractive house",
                BookedNights = new()
            }
        };

        public IEnumerable<Property> GetAll()
        {
            return _properties;
        }

        public Property Add(Property property)
        {
            _properties.Add(property);
            return property;
        }
    }
}
