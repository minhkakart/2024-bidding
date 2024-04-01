using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductImageController(IProductImageService productImageService) : ControllerBase
	{
		private readonly IProductImageService _productImageService = productImageService;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductImage>>> GetAll()
		{
			var productImages = await _productImageService.GetAll();
			return Ok(productImages);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductImage>> GetById(int id)
		{
			var productImage = await _productImageService.GetById(id);
			if (productImage == null)
			{
				return NotFound();
			}
			return Ok(productImage);
		}

	}
}
