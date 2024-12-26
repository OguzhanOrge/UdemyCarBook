using Microsoft.AspNetCore.Mvc;

namespace Udemy.CarBook.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
