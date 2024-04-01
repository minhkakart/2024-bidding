using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.OrderDetail
{
	public class OrderDetailUpdateRequest
	{
		[Required]
		public int order_detail_id { get; set; }
		[Required]
		public int product_id { get; set; }
		[Required]
		public int order_id { get; set; }
	}
}
