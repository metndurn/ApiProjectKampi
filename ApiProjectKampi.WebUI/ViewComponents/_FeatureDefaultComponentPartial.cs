using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebUI.ViewComponents
{
	public class _FeatureDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
