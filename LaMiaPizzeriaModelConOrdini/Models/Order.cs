﻿

namespace LaMiaPizzeriaModelConOrdini.Models
{
	public class Order
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public List<Pizza> Pizzas { get; set; }

		public Order() { }
	}
}
