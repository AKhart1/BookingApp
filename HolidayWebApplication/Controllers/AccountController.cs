using DomainLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBookingRepository _repository;
        private readonly UserManager<IdentityUser> _manager;

        public AccountController(
            IBookingRepository repository, UserManager<IdentityUser> manager)
        {
            _repository = repository;
            _manager = manager;
        }

        public IActionResult Index()
        {
            var userId = _manager.Users.FirstOrDefault()?.Id;
            var bookings = _repository.GetBookedPropertyByUser(userId);

            return View(bookings);
        }
    }
}
