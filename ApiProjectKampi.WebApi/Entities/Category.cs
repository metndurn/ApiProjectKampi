namespace ApiProjectKampi.WebApi.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public List<Product> Products { get; set; }//kategoriye ait ürünleri tutmak ve bire cok ilişki boyle yazılır
	}
}
