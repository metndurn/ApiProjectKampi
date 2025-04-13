namespace ApiProjectKampi.WebApi.Entities
{
	public class Contact
	{
		public string Email { get; internal set; }
		public string MapLocation { get; internal set; }
		public string Address { get; internal set; }
		public string Phone { get; internal set; }
		public string OpenHours { get; internal set; }
		public int ContactId { get; internal set; }
	}
}
