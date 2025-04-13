using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.FeatureDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;//veritabanı bağlantısı
		public FeaturesController(Mapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}
		[HttpGet]
		public IActionResult FeatureList()
		{ /*veritabanındaki ozellikleri getirir
		   ama _mapper ile olan resultfeaturedtos'tan verılerı alıyor ve listeleme isleminde map kullanılabılınır*/
			var value = _context.Features.ToList();
			return Ok(_mapper.Map<List<ResultFeatureDtos>>(value));
		}
		[HttpPost]
		public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
		{
			var value = _mapper.Map<Feature>(createFeatureDto);//veritabanına eklemek için createFeatureDto'dan Feature'a map ediliyor
			_context.Features.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme islemi basarili.:");
		}
		[HttpDelete]
		public IActionResult DeleteFeature(int id)//ozellik silme işlemi
		{
			var value = _context.Features.Find(id);
			_context.Features.Remove(value);
			_context.SaveChanges();
			return Ok("Silme islemi basarili.");
		}
		[HttpGet("GetFeature")]
		public IActionResult GetFeature(int id)//id'ye göre ozellik getirir
		{
			var value = _context.Features.Find(id);
			return Ok(_mapper.Map<GetByIdFeatureDto>(value));
		}

		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)//ozellik güncelleme
		{
			var value = _mapper.Map<Feature>(updateFeatureDto);
			_context.Features.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme islemi basarili.");
		}
	}
}
