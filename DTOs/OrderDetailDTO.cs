namespace WebApi.DTOs
{
	public class OrderDetailDTO
	{
		public int order_detail_id { get; set; }
		public int product_id { get; set; }
		public int order_id { get; set; }
		public ProductDTO? product { get; set; }
		public OrderDetailDTO() { }
	}
}
