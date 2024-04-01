using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IUserProfileService
	{
		Task<IEnumerable<UserProfile>> GetAll();
		Task<UserProfile> GetById(int id);
		Task Create(UserProfile userProfile);
		Task Update(UserProfile userProfile);
		Task Delete(int id);
	}
	public class UserProfileService(IUserProfileRepository userProfileRepository) : IUserProfileService
	{
		private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;

		public async Task Create(UserProfile userProfile)
		{
			await _userProfileRepository.Create(userProfile);
		}

		public async Task Delete(int id)
		{
			await _userProfileRepository.Delete(id);
		}

		public async Task<IEnumerable<UserProfile>> GetAll()
		{
			return await _userProfileRepository.GetAll();
		}

		public async Task<UserProfile> GetById(int id)
		{
			return await _userProfileRepository.GetById(id);
		}

		public async Task Update(UserProfile userProfile)
		{
			await _userProfileRepository.Update(userProfile);
		}
	}
}
