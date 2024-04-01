using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ProductImage
{
	public class ProductImageUpdateRequest
	{
		[Required]
		public int image_id { get; set; }
		[Required]
		public int product_id { get; set; }
		[Required]
		public string? image_url { get; set; }
	}
}
