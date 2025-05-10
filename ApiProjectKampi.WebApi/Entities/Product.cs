﻿namespace ApiProjectKampi.WebApi.Entities
{
	public class Product
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public int? CategoryId { get; set; }//kategori id si null olabilir
		public Category Category { get; set; }//categoryleri ilişkilendirmek için yazdık
	}
}
