namespace WebApi.Entities
{
	public class Product
	{
		public int product_id { get; set; }
		public int category_id { get; set; }
		public int author_id { get; set; }
		public string? product_name { get; set; }
		public decimal price { get; set; }
		public string? description { get; set; }
	}
}
