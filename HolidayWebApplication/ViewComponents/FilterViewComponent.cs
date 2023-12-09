using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLayer.ViewComponents
{
    public class FilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
