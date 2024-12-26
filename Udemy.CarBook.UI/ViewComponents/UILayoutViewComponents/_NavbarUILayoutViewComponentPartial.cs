using Microsoft.AspNetCore.Mvc;

namespace Udemy.CarBook.UI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
