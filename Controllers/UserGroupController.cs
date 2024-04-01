using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserGroupController(IUserGroupService userGroupService) : ControllerBase
	{
		private readonly IUserGroupService _userGroupService = userGroupService;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var userGroups = await _userGroupService.GetAll();
			return Ok(userGroups);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var userGroup = await _userGroupService.GetById(id);
			return Ok(userGroup);
		}

	}
}
