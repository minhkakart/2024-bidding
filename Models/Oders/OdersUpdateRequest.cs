using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Oders
{
	public class OdersUpdateRequest: UpdateRequestBase
	{
		[Required]
		public int order_id { get; set; }
		[Required]
		public int user_id { get; set; }
		/*[Required]
		public string? order_date { get; set; }*/
	}
}
