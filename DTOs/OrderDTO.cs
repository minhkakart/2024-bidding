using WebApi.Entities;

namespace WebApi.DTOs
{
	public class OrderDTO
	{
		public int order_id { get; set; }
		public int user_id { get; set; }
		public DateTime order_date { get; set; }
		public UserDTO? user { get; set; }
		public List<OrderDetailDTO> order_items { get; set; }
		public OrderDTO()
		{
			order_items = new List<OrderDetailDTO>();
		}
	}
}
