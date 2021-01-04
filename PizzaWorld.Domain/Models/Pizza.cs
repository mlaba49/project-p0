using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models {
    public class Pizza : APizzaModel {

        public Pizza(string _Crust, string _Size, List<string> _Toppings) {
            AddCrust(_Crust);
            AddSize(_Size);
            AddToppings(_Toppings);
        }

    }
}