using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChefsController : ControllerBase
	{
		private readonly ApiContext _context;//yapıcı metod ile bağlıyoruz
		public ChefsController(ApiContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult ChefList()//sef listeleme islemi
		{
			var chefs = _context.Chefs.ToList();
			return Ok(chefs);
		}
		[HttpPost]
		public IActionResult CreateChef(Chef chef)//sef ekleme islemi
		{
			_context.Chefs.Add(chef);
			_context.SaveChanges();
			return Ok("Şef ekleme islemi basarili.:");
		}
		[HttpDelete]
		public IActionResult DeleteChef(int id)//şef silme islemi
		{
			var value = _context.Chefs.Find(id);
			_context.Chefs.Remove(value);
			_context.SaveChanges();
			return Ok("Şef silme islemi basarili.");
		}
		[HttpGet("GetChef")]
		public IActionResult GetChef(int id)//şef id'ye gore listeleme islemi 
		{
			var value = _context.Chefs.Find(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateChef(Chef chef)//şef güncelleme islemi
		{
			_context.Chefs.Update(chef);
			_context.SaveChanges();
			return Ok("Şef güncelleme islemi basarili.");
		}
	}
}
