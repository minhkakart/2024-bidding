namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.DTOs;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface IOrderRepository
	{
		Task<IEnumerable<OrderDTO>> GetAll();
		Task<IEnumerable<OrderDTO>> GetAllByUser(int user_id);
		Task<OrderDTO> GetById(int id);
		Task Create(Order oder);
		Task Update(Order oder);
		Task Delete(int id);
	}
	public class OrderRepository(DataContext context, IOrderDetailRepository oderDetailRepository) : IOrderRepository
	{
		private readonly DataContext _context = context;
		private readonly IOrderDetailRepository _oderDetailRepository = oderDetailRepository;

		public async Task<IEnumerable<OrderDTO>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM Orders AS o
				JOIN `orderdetail` AS od 
				ON od.order_id = o.order_id";
			var odersQuery = await connection.QueryAsync<OrderDTO, OrderDetailDTO, OrderDTO>(sql, (o, od) =>
			{
				o.order_items.Add(od);
				return o;
			}, splitOn: "order_detail_id");

			foreach (var oder in odersQuery)
			{
				foreach (var oderItem in oder.order_items)
				{
					var x = await _oderDetailRepository.GetById(oderItem.order_detail_id);
					oderItem.product = x.product;
				}
			}

			var oders = odersQuery.GroupBy(o => o.order_id).Select(g =>
			{
				var groupedOrder = g.First();
				groupedOrder.order_items = g.Select(o => o.order_items.Single()).ToList();
				return groupedOrder;
			});

			return oders;
		}
		public async Task<OrderDTO> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM Orders AS o
				JOIN `orderdetail` AS od ON od.order_id = o.order_id
				WHERE o.order_id = @id";
			var odersQuery = await connection.QueryAsync<OrderDTO, OrderDetailDTO, OrderDTO>(sql, (o, od) =>
			{
				o.order_items.Add(od);
				return o;
			}, new { id }, splitOn: "order_detail_id");

			foreach (var oder in odersQuery)
			{
				foreach (var oderItem in oder.order_items)
				{
					var x = await _oderDetailRepository.GetById(oderItem.order_detail_id);
					oderItem.product = x.product;
				}
			}

			var oders = odersQuery.GroupBy(o => o.order_id).Select(g =>
			{
				var groupedOrder = g.First();
				groupedOrder.order_items = g.Select(o => o.order_items.Single()).ToList();
				return groupedOrder;
			});

			return oders.FirstOrDefault(new OrderDTO());
		}
		public async Task Create(Order oder)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				INSERT INTO Orders (user_id, order_date)
				VALUES (@user_id, @order_date)";
			await connection.ExecuteAsync(sql, oder);
		}
		public async Task Update(Order oder)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				UPDATE Orders
				SET user_id = @user_id, order_date = @order_date
				WHERE order_id = @order_id";
			await connection.ExecuteAsync(sql, oder);
		}

		public async Task Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				DELETE FROM Orders
				WHERE order_id = @id";
			await connection.ExecuteAsync(sql, new { id });
		}

		public async Task<IEnumerable<OrderDTO>> GetAllByUser(int user_id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM Orders AS o
				JOIN `orderdetail` AS od ON od.order_id = o.order_id
				WHERE o.user_id = @user_id";
			var odersQuery = await connection.QueryAsync<OrderDTO, OrderDetailDTO, OrderDTO>(sql, (o, od) =>
			{
				o.order_items.Add(od);
				return o;
			}, new { user_id }, splitOn: "order_detail_id");

			foreach (var oder in odersQuery)
			{
				foreach (var oderItem in oder.order_items)
				{
					var x = await _oderDetailRepository.GetById(oderItem.order_detail_id);
					oderItem.product = x.product;
				}
			}

			var oders = odersQuery.GroupBy(o => o.order_id).Select(g =>
			{
				var groupedOrder = g.First();
				groupedOrder.order_items = g.Select(o => o.order_items.Single()).ToList();
				return groupedOrder;
			});

			return oders;
		}
	}
}
