using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Category
{
	public class CategoryUpdateRequest
	{
		[Required]
		public int category_id { get; set; }
		[Required]
		public string? category_name { get; set; }
	}
}
