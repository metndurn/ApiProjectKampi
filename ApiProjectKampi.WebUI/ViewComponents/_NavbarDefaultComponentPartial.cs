using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebUI.ViewComponents
{
	public class _NavbarDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
