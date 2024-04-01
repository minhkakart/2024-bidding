using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tag
{
	public class TagCreateRequest
	{
		[Required]
		public string? tag_name { get; set; }
	}
}
