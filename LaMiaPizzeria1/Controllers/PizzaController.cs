using LaMiaPizzeriaModel.Database;
using LaMiaPizzeriaModel.Models;
using LaMiaPizzeriaModel.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace LaMiaPizzeriaModel.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using(PizzaContext db = new PizzaContext())
            {
                List<Pizza> listPizzas = db.Pizzas.ToList<Pizza>();
                return View("Index", listPizzas);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaFound = db.Pizzas
                    .Where(PizzaNelDb => PizzaNelDb.Id == id)
                    .FirstOrDefault();

                if (pizzaFound != null)
                {
                    return View(pizzaFound);
                }


                return NotFound("La pizza non esiste!");
            }
                
            
        }

        // METODO GET
        [HttpGet]
        public IActionResult Create()
        {
            using(PizzaContext db = new PizzaContext())
            {
                List<Category> categoriesFromDb = db.Categories.ToList<Category>();

                PizzaCategoriesView modelForView = new PizzaCategoriesView();
                modelForView.Categories = categoriesFromDb;

                return View("Create", modelForView);
            }
            
        }


        // METODO POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategoriesView formData)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    List<Category> categories = db.Categories.ToList<Category>();
                    formData.Categories = categories;
                }
                    return View("Create", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(formData.Pizza);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // METODO PUT (GET + POST)

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify == null)
                {
                    return NotFound("La pizza non è stata trovata");
                }

                return View("Update", pizzaToModify);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(pizza => pizza.Id == formData.Id).FirstOrDefault();

                if(pizzaToUpdate != null)
                {
                    pizzaToUpdate.Image = formData.Image;
                    pizzaToUpdate.Name = formData.Name;
                    pizzaToUpdate.Description = formData.Description;
                    pizzaToUpdate.Price = formData.Price;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La pizza che volevi modificare non è stata trovata");
                }
            }

        }


        //METODO DELETE (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if(pizzaToDelete != null)
                {
                    db.Pizzas.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                } else
                {
                    return NotFound("La pizza da eliminare non è stata trovata");
                }
            }
        }

    }
}
