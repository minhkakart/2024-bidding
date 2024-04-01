namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.DTOs;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface IOrderDetailRepository
	{
		Task<IEnumerable<OrderDetailDTO>> GetAll();
		Task<OrderDetailDTO> GetById(int id);
		Task Create(OrderDetail oderDetail);
		Task Update(OrderDetail oderDetail);
		Task Delete(int id);
	}
	public class OrderDetailRepository(DataContext context, IProductRepository productRepository) : IOrderDetailRepository
	{
		private readonly DataContext _context = context;
		private readonly IProductRepository _productRepository = productRepository;

		public async Task<IEnumerable<OrderDetailDTO>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM `orderdetail`;";
			var orderDetails = await connection.QueryAsync<OrderDetailDTO>(sql);

			foreach (var orderDetail in orderDetails)
			{
				orderDetail.product = await _productRepository.GetById(orderDetail.product_id);
			}

			return orderDetails;
		}
		public async Task<OrderDetailDTO> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM `orderdetail`
				WHERE order_detail_id = @id;";
			var orderDetailQuery = await connection.QueryAsync<OrderDetailDTO>(sql, new { id });
			var orderDetail = orderDetailQuery.FirstOrDefault(new OrderDetailDTO());
			orderDetail.product = await _productRepository.GetById(orderDetail.product_id);
			return orderDetail;
		}
		public async Task Create(OrderDetail oderDetail)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				INSERT INTO OrderDetail (order_id, product_id)
				VALUES (@order_id, @product_id);";
			await connection.ExecuteAsync(sql, oderDetail);
		}
		public async Task Update(OrderDetail oderDetail)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				UPDATE OrderDetail
				SET order_id = @order_id, product_id = @product_id
				WHERE order_detail_id = @order_detail_id;";
			await connection.ExecuteAsync(sql, oderDetail);
		}

		public async Task Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				DELETE FROM OrderDetail
				WHERE order_detail_id = @id
				";
			await connection.ExecuteAsync(sql, new { id });
		}
	}
}
