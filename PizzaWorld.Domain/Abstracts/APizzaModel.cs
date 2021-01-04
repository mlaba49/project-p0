using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWorld.Domain.Abstracts {

    public class APizzaModel : AEntity {
        public string Crust { get; set; }
        public string Size { get; set; }
        
        [NotMapped]
        public List<string> Toppings { get; set; }

        public long OrderEntityId { get; set; }

        public APizzaModel() {
            
        }

        public APizzaModel(string _Crust, string _Size, List<string> _Toppings) {
            AddCrust(_Crust);
            AddSize(_Size);
            AddToppings(_Toppings);
        }

        protected virtual void AddCrust(string _Crust) {
            Crust = _Crust;
        }

        protected virtual void AddSize(string _Size) {
            Size = _Size;
        }

        protected virtual void AddToppings(List<string> _Toppings) {
            Toppings = _Toppings;
        }

        public override string ToString()
        {
            return "Crust: " + Crust + ", Size: " + Size;
        }
    }

}