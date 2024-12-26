using Microsoft.AspNetCore.Mvc;
namespace Udemy.CarBook.UI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
