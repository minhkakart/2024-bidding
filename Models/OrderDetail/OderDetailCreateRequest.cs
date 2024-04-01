using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.OrderDetail
{
	public class OderDetailCreateRequest
	{
		[Required]
		public int product_id { get; set; }
		[Required]
		public int order_id { get; set; }
	}
}
