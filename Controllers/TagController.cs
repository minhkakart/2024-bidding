using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TagController(ITagService tagService) : ControllerBase
	{
		private readonly ITagService _tagService = tagService;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var tags = await _tagService.GetAll();
			return Ok(tags);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var tag = await _tagService.GetById(id);
			return Ok(tag);
		}

	}
}
