namespace WebApi.Entities
{
	public class UserProfile
	{
		public int profile_id { get; set; }
		public int user_id { get; set; }
		public string? fullname { get; set; }
		public string? phone { get; set; }
		public string? email { get; set; }
		public string? address { get; set; }
	}
}
