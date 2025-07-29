using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebUI.ViewComponents
{
	public class _ServiceDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
