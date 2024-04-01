using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductTagController(IProductTagService productTagService) : ControllerBase
	{
		private readonly IProductTagService _productTagService = productTagService;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductTag>>> GetAll()
		{
			var productTags = await _productTagService.GetAll();
			return Ok(productTags);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductTag>> GetById(int id)
		{
			var productTag = await _productTagService.GetById(id);
			if (productTag == null)
			{
				return NotFound();
			}
			return Ok(productTag);
		}

	}
}
