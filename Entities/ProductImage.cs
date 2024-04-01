namespace WebApi.Entities
{
	public class ProductImage
	{
		public int image_id { get; set; }
		public int product_id { get; set; }
		public string? image_url { get; set; }
	}
}
