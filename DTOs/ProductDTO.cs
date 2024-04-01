using WebApi.Entities;

namespace WebApi.DTOs
{
	public class ProductDTO
	{
		public int product_id { get; set; }
		public int category_id { get; set; }
		public int author_id { get; set; }
		public string? product_name { get; set; }
		public decimal price { get; set; }
		public string? description { get; set; }
		public Author? Author { get; set; }
		public Category? Category { get; set; }
		public List<ProductImage> ProductImages { get; set; }

		public List<Tag> Tags { get; set; }

		public ProductDTO()
		{
			Tags = new List<Tag>();
			ProductImages = new List<ProductImage>();
		}
	}
}
