using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Repositories
{
	public interface IProductRepository
	{
		Task<PaginateProduct> GetAll(int page);
		Task<ProductDTO> GetById(int id);
		Task Create(Product product);
		Task Update(Product product);
		Task Delete(int id);
		Task<IEnumerable<ProductDTO>> GetAllByCategory(int category_id);
		Task<IEnumerable<ProductDTO>> GetAllByAuthor(int author_id);
		Task<PaginateProduct> SearchByName(string name, int page);
	}

	public class ProductRepository(DataContext dataContext) : IProductRepository
	{
		public DataContext _dataContext = dataContext;

		public async Task<PaginateProduct> GetAll(int page)
		{
			using var connection = _dataContext.CreateConnection();

			var count = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM `product`;");
			var totalPage = (int)Math.Ceiling((double)count / 5);
			if (page > totalPage)
			{
				page = totalPage;
			}
			if (page < 1)
			{
				page = 1;
			}
			var offset = (page - 1) * 5;


			var sql = @"SELECT * FROM `product` as p
					JOIN `producttag` AS pt ON pt.product_id = p.product_id
					JOIN `tag` as t ON t.tag_id = pt.tag_id
					JOIN `productimage` as pi ON pi.product_id = p.product_id
					JOIN `category` AS c ON c.category_id = p.category_id
					JOIN `author` as a ON a.author_id = p.author_id
					ORDER BY p.product_id ASC;";

			var products = await connection.QueryAsync<ProductDTO, Tag, ProductImage, Category, Author, ProductDTO>(sql, (product, tag, img, cate, author) =>
			{	
				product.Category = cate;
				product.Author = author;
				product.ProductImages.Add(img);
				product.Tags.Add(tag);
				return product;
			}, splitOn: "product_tag_id, image_id, category_id, author_id");

			var result = products.GroupBy(p => p.product_id).Select(g =>
			{
				var groupedProduct = g.First();
				groupedProduct.Tags = g.Select(p => p.Tags.Single()).DistinctBy(t => t.tag_id).ToList();
				groupedProduct.ProductImages = g.Select(p => p.ProductImages.Single()).DistinctBy(i => i.image_id).ToList();
				return groupedProduct;
			}).Take(new Range(offset, offset + 5));

			return new PaginateProduct { 
				Page = page,
				TotalPage = totalPage,
				Products = result
			};
		}

		public async Task<ProductDTO> GetById(int id)
		{
			using var connection = _dataContext.CreateConnection();
			var sql = @"SELECT * FROM `product` as p
					JOIN `producttag` AS pt ON pt.product_id = p.product_id
					JOIN `tag` as t ON t.tag_id = pt.tag_id
					JOIN `productimage` as pi ON pi.product_id = p.product_id
					JOIN `category` AS c ON c.category_id = p.category_id
					JOIN `author` as a ON a.author_id = p.author_id
					WHERE p.product_id = @id;";

			var products = await connection.QueryAsync<ProductDTO, Tag, ProductImage, Category, Author, ProductDTO>(sql, (product, tag, img, cate, author) =>
			{
				product.Category = cate;
				product.Author = author;
				product.ProductImages.Add(img);
				product.Tags.Add(tag);
				return product;
			}, new { id }, splitOn: "product_tag_id, image_id, category_id, author_id");

			var result = products.GroupBy(p => p.product_id).Select(g =>
			{
				var groupedProduct = g.First();
				groupedProduct.Tags = g.Select(p => p.Tags.Single()).DistinctBy(t => t.tag_id).ToList();
				groupedProduct.ProductImages = g.Select(p => p.ProductImages.Single()).DistinctBy(i => i.image_id).ToList();
				return groupedProduct;
			});
			return result.FirstOrDefault(new ProductDTO());
		}

		public async Task Create(Product product)
		{
			using var connection = _dataContext.CreateConnection();
			var sql = @"
				INSERT INTO Product (category_id, author_id, product_name, price, description)
				VALUES (@category_id, @author_id, @product_name, @price, @description);";
			await connection.ExecuteScalarAsync<int>(sql, product);
		}

		public async Task Update(Product product)
		{
			using var connection = _dataContext.CreateConnection();
			var sql = @"
				UPDATE Product
				SET category_id = @category_id,
				author_id = @author_id,
				product_name = @product_name,
				price = @price,
				description = @description
				WHERE product_id = @product_id;";
			await connection.ExecuteAsync(sql, product);
		}

		public async Task Delete(int id)
		{
			using var connection = _dataContext.CreateConnection();
			var sql = "DELETE FROM Product WHERE product_id = @id";
			await connection.ExecuteAsync(sql, new { id });
		}

		public async Task<IEnumerable<ProductDTO>> GetAllByCategory(int category_id)
		{
			using var connection = _dataContext.CreateConnection();
			var sql = @"SELECT * FROM `product` as p
					JOIN `producttag` AS pt ON pt.product_id = p.product_id
					JOIN `tag` as t ON t.tag_id = pt.tag_id
					JOIN `productimage` as pi ON pi.product_id = p.product_id
					JOIN `category` AS c ON c.category_id = p.category_id
					JOIN `author` as a ON a.author_id = p.author_id
					WHERE p.category_id = @category_id;";

			var products = await connection.QueryAsync<ProductDTO, Tag, ProductImage, Category, Author, ProductDTO>(sql, (product, tag, img, cate, author) =>
			{
				product.Category = cate;
				product.Author = author;
				product.ProductImages.Add(img);
				product.Tags.Add(tag);
				return product;
			}, new { category_id }, splitOn: "product_tag_id, image_id, category_id, author_id");

			var result = products.GroupBy(p => p.product_id).Select(g =>
			{
				var groupedProduct = g.First();
				groupedProduct.Tags = g.Select(p => p.Tags.Single()).DistinctBy(t => t.tag_id).ToList();
				groupedProduct.ProductImages = g.Select(p => p.ProductImages.Single()).DistinctBy(i => i.image_id).ToList();
				return groupedProduct;
			});
			return result;
		}

		public async Task<IEnumerable<ProductDTO>> GetAllByAuthor(int author_id)
		{
			using var connection = _dataContext.CreateConnection();
			var sql = @"SELECT * FROM `product` as p
					JOIN `producttag` AS pt ON pt.product_id = p.product_id
					JOIN `tag` as t ON t.tag_id = pt.tag_id
					JOIN `productimage` as pi ON pi.product_id = p.product_id
					JOIN `category` AS c ON c.category_id = p.category_id
					JOIN `author` as a ON a.author_id = p.author_id
					WHERE p.author_id = @author_id;";

			var products = await connection.QueryAsync<ProductDTO, Tag, ProductImage, Category, Author, ProductDTO>(sql, (product, tag, img, cate, author) =>
			{
				product.Category = cate;
				product.Author = author;
				product.ProductImages.Add(img);
				product.Tags.Add(tag);
				return product;
			}, new { author_id }, splitOn: "product_tag_id, image_id, category_id, author_id");

			var result = products.GroupBy(p => p.product_id).Select(g =>
			{
				var groupedProduct = g.First();
				groupedProduct.Tags = g.Select(p => p.Tags.Single()).DistinctBy(t => t.tag_id).ToList();
				groupedProduct.ProductImages = g.Select(p => p.ProductImages.Single()).DistinctBy(i => i.image_id).ToList();
				return groupedProduct;
			});
			return result;
		}

		public async Task<PaginateProduct> SearchByName(string name, int page)
		{
			using var connection = _dataContext.CreateConnection();

			var countSql = @"SELECT COUNT(product_id) FROM `product` 
							WHERE product_id IN 
								(SELECT product_id FROM `product` 
								WHERE product_name LIKE '%"+name+@"%' 
								GROUP BY product_id);";
			var count = await connection.ExecuteScalarAsync<int>(countSql);
			var totalPage = (int)Math.Ceiling((double)count / 5);
			if (page > totalPage)
			{
				page = totalPage;
			}
			if (page < 1)
			{
				page = 1;
			}
			var offset = (page - 1) * 5;



			var sql = @"SELECT * FROM `product` as p
					JOIN `producttag` AS pt ON pt.product_id = p.product_id
					JOIN `tag` as t ON t.tag_id = pt.tag_id
					JOIN `productimage` as pi ON pi.product_id = p.product_id
					JOIN `category` AS c ON c.category_id = p.category_id
					JOIN `author` as a ON a.author_id = p.author_id
					WHERE p.product_name LIKE '%"+name+@"%'
					ORDER BY p.product_id ASC;";

			var products = await connection.QueryAsync<ProductDTO, Tag, ProductImage, Category, Author, ProductDTO>(sql, (product, tag, img, cate, author) =>
			{
				product.Category = cate;
				product.Author = author;
				product.ProductImages.Add(img);
				product.Tags.Add(tag);
				return product;
			}, new {name}, splitOn: "product_tag_id, image_id, category_id, author_id");

			var result = products.GroupBy(p => p.product_id).Select(g =>
			{
				var groupedProduct = g.First();
				groupedProduct.Tags = g.Select(p => p.Tags.Single()).DistinctBy(t => t.tag_id).ToList();
				groupedProduct.ProductImages = g.Select(p => p.ProductImages.Single()).DistinctBy(i => i.image_id).ToList();
				return groupedProduct;
			}).Take(new Range(offset, offset + 5));
			return new PaginateProduct
			{
				Page = page,
				TotalPage = totalPage,
				Products = result
			};
		}
	}
}
