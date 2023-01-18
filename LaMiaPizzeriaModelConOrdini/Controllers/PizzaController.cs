
using LaMiaPizzeriaModelConOrdini.Database;
using LaMiaPizzeriaModelConOrdini.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaModelConOrdini.Controllers
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
                //Con include gli dico di non usare il lazy coding e di prendermi anche l'oggetto category.
                Pizza pizzaFound = db.Pizzas
                    .Where(PizzaNelDb => PizzaNelDb.Id == id)
                    .Include(pizza => pizza.Category)
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

                List<Category> categories = db.Categories.ToList<Category>();

                PizzaCategoriesView modelForView = new PizzaCategoriesView();
                modelForView.Pizza = pizzaToModify;
                modelForView.Categories = categories;

                return View("Update", modelForView);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaCategoriesView formData)
        {
            if (!ModelState.IsValid)
            {
                using(PizzaContext db = new PizzaContext())
                {
                    List<Category> categories = db.Categories.ToList<Category>();
                    formData.Categories = categories;
                }

                return View("Update", formData);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if(pizzaToUpdate != null)
                {
                    pizzaToUpdate.Image = formData.Pizza.Image;
                    pizzaToUpdate.Name = formData.Pizza.Name;
                    pizzaToUpdate.Description = formData.Pizza.Description;
                    pizzaToUpdate.Price = formData.Pizza.Price;
                    pizzaToUpdate.CategoryId = formData.Pizza.CategoryId;

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
