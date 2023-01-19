


namespace LaMiaPizzeriaModelConOrdini.Models
{
	public class Order
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int PizzaId { get; set; }
		public Pizza Pizza { get; set; }

		public Order() 
		{
		
		}
    }
}
