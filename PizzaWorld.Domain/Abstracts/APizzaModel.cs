using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWorld.Domain.Abstracts {

    public class APizzaModel : AEntity {
        public string Crust { get; set; }
        public string Size { get; set; }
        
        public string Topping1 { get; set; }
        public string Topping2 { get; set; }
        public string Topping3 { get; set; }
        public string Topping4 { get; set; }
        public string Topping5 { get; set; }

        public long OrderEntityId { get; set; }

        public APizzaModel() {
            
        }

        public APizzaModel(string _Crust, string _Size, string _Topping1, string _Topping2, string _Topping3, string _Topping4, string _Topping5) {
            AddCrust(_Crust);
            AddSize(_Size);
            AddToppings(_Topping1, _Topping2, _Topping3, _Topping4, _Topping5);
        }

        protected virtual void AddCrust(string _Crust) {
            Crust = _Crust;
        }

        protected virtual void AddSize(string _Size) {
            Size = _Size;
        }

        protected virtual void AddToppings(string _Topping1, string _Topping2, string _Topping3, string _Topping4, string _Topping5) {
            Topping1 = _Topping1;
            Topping2 = _Topping2;
            Topping3 = _Topping3;
            Topping4 = _Topping4;
            Topping5 = _Topping5;
        }

        public override string ToString()
        {
            return "Crust: " + Crust + ", Size: " + Size + ", Toppings: " + Topping1 + ", " + Topping2 + ", " + Topping3 + ", " + Topping4 + ", " + Topping5;
        }
    }

}