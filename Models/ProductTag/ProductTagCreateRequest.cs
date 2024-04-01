using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ProductTag
{
	public class ProductTagCreateRequest
	{
		[Required]
		public int product_id { get; set; }
		[Required]
		public int tag_id { get; set; }
	}
}
