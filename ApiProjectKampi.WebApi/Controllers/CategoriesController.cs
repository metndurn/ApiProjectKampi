﻿using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiContext _context;//yapıcı metod ile bağlıyoruz
		public CategoriesController(ApiContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult CategoryList()
		{
			var categories = _context.Categories.ToList();
			return Ok(categories);
		}
		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return Ok("Kategori ekleme islemi basarili.:");
		}
		[HttpDelete]
		public IActionResult DeleteCategory(int id)
		{
			var value = _context.Categories.Find(id);
			_context.Categories.Remove(value);
			_context.SaveChanges();
			return Ok("Kategori silme islemi basarili.");
		}
		/*http kodları bir kez kullanılır fazla kullanmak ıcın yanına muhakkak metod ısmı yazılmalıdır*/
		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			var value = _context.Categories.Find(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCategory(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();
			return Ok("Kategori güncelleme islemi basarili.");
		}
	}
}
