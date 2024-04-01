namespace WebApi.Entities
{
	public class Order
	{
		public int order_id { get; set; }
		public int user_id { get; set; }
		public DateTime order_date { get; set; }
	}
}
