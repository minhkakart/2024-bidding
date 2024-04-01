using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderDetailController(IOrderDetailService oderDetailService) : ControllerBase
	{
		private readonly IOrderDetailService _oderDetailService = oderDetailService;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var orderDetails = await _oderDetailService.GetAll();
			return Ok(orderDetails);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var orderDetail = await _oderDetailService.GetById(id);
			return Ok(orderDetail);
		}

	}
}
