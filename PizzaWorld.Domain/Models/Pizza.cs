using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models {
    public class Pizza : APizzaModel {

        //public List<string> Toppings { get; set; }
        //public string Crust { get; set; }
        //public string Size { get; set; }
        public double Price { get; set; }

    }
}