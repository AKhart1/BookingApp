using DomainLayer.Entities;
using DomainLayer.Repositories;
using WebApplicationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLayer.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingController(
            IBookingRepository repository, UserManager<IdentityUser> manager)
        {
            _bookingRepository = repository;
            _userManager = manager;
        }

        [HttpPost]
        public IActionResult SubmitBooking(
            int propertyId, DateTime startDate, DateTime endDate, string userEmail, string billingAddress)
        {
            var userId = _userManager.Users.FirstOrDefault()?.Id;

            var book = new Booking
            {
                PropertyId = propertyId,
                UserId = userId,
                UserEmail = userEmail,
                BillingAddress = billingAddress,
                StartDate = startDate,
                EndDate = endDate
            };


            book = _bookingRepository.MakeBooking(book);

            if (book != null)
                return View("BookingSuccess", book);
            else
                return View("BookingFailure");
        }


        [HttpPost]
        public IActionResult BookProperty(DateTime start, DateTime end, int propertyId)
        {
            var book = new CreateBookingModel
            {
                StartDate = start,
                EndDate = end,
                PropertyId = propertyId
            };

            return View("CreateBooking", book);
        }
    }
}
