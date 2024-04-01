using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Category
{
	public class CategoryCreateRequest
	{
		[Required]
		public string? category_name { get; set; }
	}
}
