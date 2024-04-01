using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tag
{
	public class TagUpdateRequest
	{
		[Required]
		public int tag_id { get; set; }
		[Required]
		public string? tag_name { get; set; }
	}
}
