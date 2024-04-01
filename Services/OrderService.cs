using Mysqlx.Crud;
using WebApi.DTOs;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderDTO>> GetAll();
		Task<IEnumerable<OrderDTO>> GetAllByUser(int user_id);
		Task<OrderDTO> GetById(int id);
		Task Create(Order oder);
		Task Update(Order oder);
		Task Delete(int id);
	}
	public class OrderService(IOrderRepository oderRepository) : IOrderService
	{
		private readonly IOrderRepository _oderRepository = oderRepository;

		public Task Create(Order oder)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			await _oderRepository.Delete(id);
		}

		public async Task<IEnumerable<OrderDTO>> GetAll()
		{
			return await _oderRepository.GetAll();
		}

		public async Task<IEnumerable<OrderDTO>> GetAllByUser(int user_id)
		{
			return await _oderRepository.GetAllByUser(user_id);
		}

		public async Task<OrderDTO> GetById(int id)
		{
			return await _oderRepository.GetById(id);
		}

		public Task Update(Order oder)
		{
			throw new NotImplementedException();
		}
	}
}
