using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.ProductDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IValidator<Product> _validator;
		private readonly ApiContext _context;
		private readonly IMapper _mapper;//mapper nesnesi ile dto ve entity sınıfları arasında dönüşüm yapacağız

		public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
		{
			_validator = validator;
			_context = context;
			_mapper = mapper;
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
		[HttpPost("CreateProductWithCategory")]
		public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);// AutoMapper kullanarak CreateProductDto'dan Product'a dönüştürüyoruz
			_context.Products.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme işlemi başarılı");
		}
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()// Category ile ilişkili ürünleri listelemek için
		{
			var values = _context.Products.Include(x => x.Category).ToList(); // Include ile Category'yi de dahil ediyoruz
			return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));// AutoMapper kullanarak Product listesini ResultProductWithCategoryDto'ya dönüştürüyoruz
		}
	}
}
