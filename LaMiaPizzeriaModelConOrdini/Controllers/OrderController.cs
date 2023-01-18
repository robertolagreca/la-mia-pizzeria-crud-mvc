using LaMiaPizzeriaModelConOrdini.Database;
using LaMiaPizzeriaModelConOrdini.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaModelConOrdini.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			using (PizzaContext db = new PizzaContext())
			{
				List<Order> listOrders = db.Orders.ToList<Order>();

				return View("Index", listOrders);
			}
		}

		// METODO GET
		[HttpGet]
		public IActionResult Create()
		{
			using (PizzaContext db = new PizzaContext())
			{
				List<Pizza> pizzasFromDb = db.Pizzas.ToList<Pizza>();

				PizzaOrdersView modelOrderForView = new PizzaOrdersView();
				modelOrderForView.Pizzas = pizzasFromDb;

				return View("Create", modelOrderForView);
			}

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PizzaOrdersView formData)
		{
			if (!ModelState.IsValid)
			{
				using (PizzaContext db = new PizzaContext())
				{
					List<Pizza> pizzas = db.Pizzas.ToList<Pizza>();
					formData.Pizzas = pizzas;
				}
				return View("Create", formData);
			}

			using (PizzaContext db = new PizzaContext())
			{
				db.Orders.Add(formData.Order);
				db.SaveChanges();
			}

			return RedirectToAction("Index", "Pizza");
		}
	}
}
