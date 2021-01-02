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
            if(Crust == "CHEESE") Price += 5;
            if(Size == "SMALL") Price -= 5;
            if(Size == "LARGE") Price += 5;
            Price += Toppings.Count * 5;
        }

    }
}