using System.Collections.Generic;
using System.Text;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Models {
    public class Order : AEntity {

        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
        public List<APizzaModel> Pizzas { get; set; }
        public double Price { get; set; }
        public long UserEntityId { get; set; }
        public long StoreEntityId1 { get; set; }

        public Order() {
            Pizzas = new List<APizzaModel>();
        }

        public void MakePizza(string Crust, string Size, List<string> Toppings) {
            Pizza p = new Pizza(Crust, Size, Toppings);
            Price += 9.99;
            if(p.Crust == "CHEESE") Price += 5;
            if(p.Size == "SMALL") Price -= 5;
            if(p.Size == "LARGE") Price += 5;
            Price += p.Toppings.Count * 5;
            Pizzas.Add(p);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var p in Pizzas) {
                sb.AppendLine(p.ToString());
            }
            return $"You have ordered these pizzas: {sb.ToString()}";
        }

        public void AssignId(long id) {
            StoreEntityId1 = id;
        }

        
    }
}