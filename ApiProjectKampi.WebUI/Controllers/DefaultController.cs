using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
