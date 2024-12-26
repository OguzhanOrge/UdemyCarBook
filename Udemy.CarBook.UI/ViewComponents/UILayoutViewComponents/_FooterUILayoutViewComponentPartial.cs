using Microsoft.AspNetCore.Mvc;
namespace Udemy.CarBook.UI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
