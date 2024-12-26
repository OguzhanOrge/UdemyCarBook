using Microsoft.AspNetCore.Mvc;

namespace Udemy.CarBook.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public IActionResult Index()
        {
            return View();
        }
    }
}
