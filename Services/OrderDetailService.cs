using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IOrderDetailService
	{
		Task<IEnumerable<OrderDetailDTO>> GetAll();
		Task<OrderDetailDTO> GetById(int id);
		Task Create(OrderDetail oderDetail);
		Task Update(OrderDetail oderDetail);
		Task Delete(int id);
	}
	public class OrderDetailService(IOrderDetailRepository oderDetailRepository) : IOrderDetailService
	{
		private readonly IOrderDetailRepository _oderDetailRepository = oderDetailRepository;

		public async Task Delete(int id)
		{
			await _oderDetailRepository.Delete(id);
		}

		public Task Create(OrderDetail oderDetail)
		{
			return _oderDetailRepository.Create(oderDetail);
		}

		public async Task<IEnumerable<OrderDetailDTO>> GetAll()
		{
			return await _oderDetailRepository.GetAll();
		}

		public Task<OrderDetailDTO> GetById(int id)
		{
			return _oderDetailRepository.GetById(id);
		}

		public async Task Update(OrderDetail oderDetail)
		{
			await _oderDetailRepository.Update(oderDetail);
		}
	}
}
