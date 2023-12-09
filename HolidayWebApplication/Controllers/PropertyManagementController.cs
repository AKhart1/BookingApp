using DomainLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplicationLayer.Models;

namespace WebApplicationLayer.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public PropertyManagementController(
            IPropertyRepository repository, IWebHostEnvironment environment)
        {
            _propertyRepository = repository;
            _WebHostEnvironment = environment;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(PropertyDetailsModel propertyDetails)
        {
            if (ModelState.IsValid)
            {
                var property = propertyDetails.ToPropertyModel();
                _propertyRepository.Add(property);

                ModelState.Clear();
            }
            return View();
        }

        public IActionResult AddImage(int id)
        {
            var model = new ImageModel { PropertyId = id };
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadImage(ImageModel model)
        {
            if (model.Image != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                var urlPath = $"/images/{fileName}";
                var filePath = Path.Combine(_WebHostEnvironment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                _propertyRepository.AddPropertyImage(model.PropertyId, urlPath);
            }

            return RedirectToAction("ViewPropertyDetails", "PropertyListing", new { id = model.PropertyId });
        }
    }
}
