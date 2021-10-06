using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza.Services;

namespace Pizza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza.Models.Pizza NewPizza { get; set; }
        public List<Pizza.Models.Pizza> pizzas;
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                pizzas = PizzaService.GetAll();
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }

        public string GlutenFreeText(Pizza.Models.Pizza pizza)
        {
            if (pizza.IsGlutenFree)
                return "Gluten free";
            return "Not gluten free";
        }
    }
}
