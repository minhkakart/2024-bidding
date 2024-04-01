using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.UserGroup
{
	public class UserGroupUpdateRequest
	{
		[Required]
		public int? group_id { get; set; }

		[Required]
		public string? group_name { get; set; }
	}
}
