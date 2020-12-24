using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models {
    public class Store : AEntity {

        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<Order> CompletedOrders { get; set; }

        public Store() {
            Orders = new List<Order>();
        }

        public void CreateOrder() {
            Orders.Add(new Order());
        }

        bool DeleteOrder(Order order) {
            try {
                Orders.Remove(order);
                return true;
            }
            catch {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        
    }
}