using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaModel = Pizza.Models.Pizza;
using Pizza.Models;

namespace Pizza.Services
{
    public static class PizzaService
    {
        static List<PizzaModel> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<PizzaModel> {
                new PizzaModel {
                    Id=1,Name="Classic Italian",Price=20.00m,Size=PizzaSize.Large,IsGlutenFree=false
                },
                new PizzaModel {
                    Id=2,Name="Veggie",Price=15.00m,Size=PizzaSize.Small,IsGlutenFree=false
                }
            };
        }
        public static List<PizzaModel> GetAll() => Pizzas;

        public static PizzaModel Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(PizzaModel pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var Pizza = Get(id);
            if (Pizza is null)
                return;
            Pizzas.Remove(Pizza);
        }

        public static void Update(PizzaModel pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;
            Pizzas[index] = pizza;
        }
    }
}
