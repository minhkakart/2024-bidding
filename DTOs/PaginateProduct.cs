namespace WebApi.DTOs
{
	public class PaginateProduct
	{
		public int Page { get; set; }
		public int TotalPage { get; set; }
		public IEnumerable<ProductDTO>? Products { get; set; }
	}
}
