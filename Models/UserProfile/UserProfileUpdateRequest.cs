using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.UserProfile
{
	public class UserProfileUpdateRequest
	{
		[Required]
		public int profile_id { get; set; }
		[Required]
		public int user_id { get; set; }
		[Required]
		public string? fullname { get; set; }
		[Required]
		public string? phone { get; set; }
		[Required]
		public string? email { get; set; }
		[Required]
		public string? address { get; set; }
	}
}
