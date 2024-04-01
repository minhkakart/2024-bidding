using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController(IProductService productService)
	{
		private readonly IProductService _productService = productService;

		[HttpGet]
		public async Task<IEnumerable<ProductDTO>> GetAll()
		{
			return await _productService.GetAll();
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
	}
}
