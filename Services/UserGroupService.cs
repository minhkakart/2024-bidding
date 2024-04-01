using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IUserGroupService
	{
		Task<IEnumerable<UserGroup>> GetAll();
		Task<UserGroup> GetById(int id);
		Task Create(UserGroup userGroup);
		Task Update(UserGroup userGroup);
		Task Delete(int id);
	}

	public class UserGroupService(IUserGroupRepository userGroupRepository) : IUserGroupService
	{
		private readonly IUserGroupRepository _userGroupRepository = userGroupRepository;
		public async Task Create(UserGroup userGroup)
		{
			await _userGroupRepository.Create(userGroup);
		}

		public async Task Delete(int id)
		{
			await _userGroupRepository.Delete(id);
		}

		public async Task<IEnumerable<UserGroup>> GetAll()
		{
			return await _userGroupRepository.GetAll();
		}

		public async Task<UserGroup> GetById(int id)
		{
			return await _userGroupRepository.GetById(id);
		}

		public async Task Update(UserGroup userGroup)
		{
			await _userGroupRepository.Update(userGroup);
		}
	}
}
