using LaMiaPizzeriaConCategoriaEOrdini.Database;
using LaMiaPizzeriaConCategoriaEOrdini.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaConCategoriaEOrdini.Controllers
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

                PizzaOrdersView modelForView = new PizzaOrdersView();
                modelForView.Pizzas = pizzasFromDb;

                return View("Create", modelForView);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Orders.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
