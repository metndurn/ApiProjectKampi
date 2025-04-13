namespace ApiProjectKampi.WebApi.Dtos.ContactDtos
{
	/*dto'larda 4 temel işlem vardır
	 ekleme, guncelleme, listeleme ve id'ye gore getırme vardır sılme yoktur butun yapıları
	entity klasorundekı entitylerden alırlar*/
	public class ResultContactDtos
	{
		public int ContactId { get; set; }
		public string MapLocation { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string OpenHours { get; set; }
	}
}
