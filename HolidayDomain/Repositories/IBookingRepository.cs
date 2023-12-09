using DomainLayer.Entities;

namespace DomainLayer.Repositories
{
    public interface IBookingRepository
    {
        Booking? MakeBooking(Booking booking);
        IEnumerable<Booking> GetBookedPropertyByUser(string? userId);
    }
}
