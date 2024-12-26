using Microsoft.AspNetCore.Mvc;

namespace Udemy.CarBook.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
