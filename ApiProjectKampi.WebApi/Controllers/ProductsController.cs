using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IValidator<Product> _validator;
		private readonly ApiContext _context;

		public ProductsController(IValidator<Product> validator, ApiContext context)
		{
			_validator = validator;
			_context = context;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			var products = _context.Products.ToList();
			return Ok(products);
		}
		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{
				_context.Products.Add(product);
				_context.SaveChanges();
				return Ok("Ürün ekleme işlemi başarılı");
			}
		}
		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var values = _context.Products.Find(id);
			_context.Products.Remove(values);
			_context.SaveChanges();
			return Ok("Ürün silme işlemi başarılı");
		}
		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			var values = _context.Products.Find(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{
				_context.Products.Update(product);
				_context.SaveChanges();
				return Ok("Ürün güncelleme işlemi başarılı");
			}
		}
	}
}
