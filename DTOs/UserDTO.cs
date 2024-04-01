using System.Text.Json.Serialization;
using WebApi.Entities;

namespace WebApi.DTOs
{
	public class UserDTO
	{
		public int? user_id { get; set; }
		public int? group_id { get; set; }
		public string? username { get; set; }
		public UserGroup? UserGroup { get; set; }
		public UserProfile? UserProfile { get; set; }
		[JsonIgnore]
		public string? PasswordHash { get; set; }
	}
}
