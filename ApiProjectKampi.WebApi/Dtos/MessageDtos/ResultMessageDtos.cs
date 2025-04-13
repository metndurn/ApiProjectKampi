﻿namespace ApiProjectKampi.WebApi.Dtos.MessageDtos
{
	public class ResultMessageDtos
	{
		public int MessageId { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string MessageDetails { get; set; }
		public DateTime SendDate { get; set; }
		public bool IsRead { get; set; }
	}
}
