using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebUI.ViewComponents
{
	public class _HeadDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
