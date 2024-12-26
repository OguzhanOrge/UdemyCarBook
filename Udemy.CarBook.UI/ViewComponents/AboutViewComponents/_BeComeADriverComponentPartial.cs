using Microsoft.AspNetCore.Mvc;

namespace Udemy.CarBook.UI.ViewComponents.AboutViewComponents
{
	public class _BeComeADriverComponentPartial : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return  View();
		}
	}
}
