using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Services;

namespace WebApi.Controllers
{

	// partial class Params
	// {
	// 	public int? page { get; set; } = 1;
	// }

	[ApiController]
	[Route("api/[controller]")]
	public class ProductController(IProductService productService)
	{
		private readonly IProductService _productService = productService;

		[HttpGet]
		public async Task<PaginateProduct> GetAll([FromQuery] int page)
		{
			return await _productService.GetAll(page == 0 ? 1 : page);
		}

		[HttpGet("{id}")]
		public async Task<ProductDTO> GetById(int id)
		{
			return await _productService.GetById(id);
		}

		[HttpGet("category/{category_id}")]
		public async Task<IEnumerable<ProductDTO>> GetAllByCategory(int category_id)
		{
			return await _productService.GetAllByCategory(category_id);
		}

		[HttpGet("author/{author_id}")]
		public async Task<IEnumerable<ProductDTO>> GetAllByAuthor(int author_id)
		{
			return await _productService.GetAllByAuthor(author_id);
		}

		[HttpGet("search")]
		public async Task<PaginateProduct> SearchByName([FromQuery] string name, [FromQuery] int page)
		{
			return await _productService.SearchByName(name, page == 0 ? 1 : page);
		}

	}
}
