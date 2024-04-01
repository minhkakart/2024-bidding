using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ProductImage
{
	public class ProductImageCreateRequest
	{
		[Required]
		public int product_id { get; set; }
		[Required]
		public string? image_url { get; set; }
	}
}
