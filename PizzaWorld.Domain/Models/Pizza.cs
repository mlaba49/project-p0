using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models {
    public class Pizza : APizzaModel {

        public double Price { get; set; }

        public Pizza(string _Crust, string _Size, List<string> _Toppings) {
            AddCrust(_Crust);
            AddSize(_Size);
            AddToppings(_Toppings);

            Price = 9.99;
            if(Crust == "cheese") Price += 5;
            if(Size == "small") Price -= 5;
            if(Size == "large") Price += 5;
            Price += Toppings.Count * 5;
        }

    }
}