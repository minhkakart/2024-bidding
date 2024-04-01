﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Product
{
	public class ProductCreateRequest
	{
		[Required]
		public int category_id { get; set; }
		[Required]
		public int author_id { get; set; }
		[Required]
		public string? product_name { get; set; }
		[Required]
		public decimal price { get; set; }
		[Required]
		public string? description { get; set; }
	}
}
