using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.UserGroup
{
	public class UserGroupCreateRequest
	{
		[Required]
		public int? group_id { get; set; }

		[Required]
		public string? group_name { get; set; }
	}
}
