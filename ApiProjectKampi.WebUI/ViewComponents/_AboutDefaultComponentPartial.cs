using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebUI.ViewComponents
{
	public class _AboutDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
