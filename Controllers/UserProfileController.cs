using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserProfileController(IUserProfileService userProfileService) : ControllerBase
	{
		private readonly IUserProfileService _userProfileService = userProfileService;

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var userProfiles = await _userProfileService.GetAll();
			return Ok(userProfiles);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var userProfile = await _userProfileService.GetById(id);
			return Ok(userProfile);
		}

	}
}
