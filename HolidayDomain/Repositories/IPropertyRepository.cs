using DomainLayer.Entities;

namespace DomainLayer.Repositories
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        IEnumerable<Property> GetAvailable(DateTime start, DateTime end);
        Property? GetById(int id);
        Property Add(Property property);
        Property BookProperty(int propId, DateTime start, DateTime end);
        PropertyImage AddPropertyImage(int propId, string iUrl);
    }
}
