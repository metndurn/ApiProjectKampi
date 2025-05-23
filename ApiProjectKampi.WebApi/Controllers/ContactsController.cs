﻿using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.ContactDtos;
using ApiProjectKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ContactsController(ApiContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult ContactList()//contact listeleme islemi
		{
			var values = _context.Contacts.ToList();
			return Ok(values);
		}
		/*dto ile elle ekleme yani manuel mapleme islemi oldu*/
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)//dto ekleme el ile
		{
			Contact contact = new Contact();
			contact.Email = createContactDto.Email;
			contact.Address = createContactDto.Address;
			contact.Phone = createContactDto.Phone;
			contact.MapLocation = createContactDto.MapLocation;
			contact.OpenHours = createContactDto.OpenHours;
			_context.Contacts.Add(contact);
			_context.SaveChanges();
			return Ok("Contact ekleme islemi basarili.");
		}
		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return Ok("Contact silme islemi basarili.");
		}
		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			var value = _context.Contacts.Find(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{

			Contact contact = new Contact();
			contact.ContactId = updateContactDto.ContactId;
			contact.Email = updateContactDto.Email;
			contact.Address = updateContactDto.Address;
			contact.Phone = updateContactDto.Phone;
			contact.MapLocation = updateContactDto.MapLocation;
			contact.OpenHours = updateContactDto.OpenHours;
			_context.Contacts.Update(contact);
			_context.SaveChanges();
			return Ok("Contact guncelleme islemi basarili.");
		}
	}
}
