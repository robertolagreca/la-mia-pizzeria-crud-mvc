
namespace LaMiaPizzeriaModelConOrdini.Models
{
	public class PizzaOrdersView
	{

		// Il post vuoto che il mio form dovrà compilare
		public Order Order { get; set; }

		// Questa lista di categories servirà per la select nel from in modo che possa far visualizzare all'utente
		// tutte le categorie da cui poter selezionare un opzione per il Post
		public List<Pizza>? Pizzas { get; set; }

	}
}
