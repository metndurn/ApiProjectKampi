﻿using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.MessageDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public MessagesController(IMapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}
		[HttpGet]
		public IActionResult MessageList()//veritabanındaki mesajları getirir
		{ /*veritabanındaki mesajları getirir
		   ama _mapper ile olan resultmessagedtos'tan verılerı alıyor ve listeleme isleminde map kullanılabılınır*/
			var value = _context.Messages.ToList();
			return Ok(_mapper.Map<List<ResultMessageDtos>>(value));
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)//veritabanına mesaj ekler
		{
			var value = _mapper.Map<Message>(createMessageDto);//veritabanına eklemek için createMessageDto'dan Message'a map ediliyor
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("Mesaj ekleme islemi basarili.:");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)//mesaj silme işlemi
		{
			var value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return Ok("Mesaj silme islemi basarili.");
		}
		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)//id'ye göre mesaj getirir
		{
			var value = _context.Messages.Find(id);
			return Ok(_mapper.Map<GetByIdMessageDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)//mesaj güncelleme
		{
			var value = _mapper.Map<Message>(updateMessageDto);//veritabanına güncellemek için updateMessageDto'dan Message'a map ediliyor
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Mesaj güncelleme islemi basarili.");
		}
	}
}
