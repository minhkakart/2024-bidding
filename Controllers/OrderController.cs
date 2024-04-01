using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController(IOrderService oderService) : ControllerBase
	{
		private readonly IOrderService _oderService = oderService;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var oders = await _oderService.GetAll();
			return Ok(oders);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var oder = await _oderService.GetById(id);
			return Ok(oder);
		}

		[HttpGet("user/{user_id}")]
		public async Task<IActionResult> GetAllByUser(int user_id)
		{
			var oders = await _oderService.GetAllByUser(user_id);
			return Ok(oders);
		}
	}
}
