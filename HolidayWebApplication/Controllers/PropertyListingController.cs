using DomainLayer.Repositories;
using WebApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLayer.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _repository;

        public PropertyListingController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ListAll()
        {
            var properties = _repository.GetAll()
                .Select(p => new PropertyListingModel(p));
            return View("ListProperties", properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var properties = _repository.GetAvailable(start, end)
                .Select(p => new PropertyListingModel(p));
            return View("ListProperties", properties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var property = _repository.GetById(id);

            if (property == null)
                return NotFound();

            return View("PropertyDetails", new PropertyDetailsModel(property));
        }
    }
}
