using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client {
    public class SqlClient {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();

        public IEnumerable<Store> ReadStores() {
            return _db.Stores;
        }
        public Store ReadOneStore(string name) {
            return _db.Stores.FirstOrDefault(s => s.Name == name);
        }
        public void SaveStore(Store store) {
            _db.Add(store);
            _db.SaveChanges();
        }
        public void Update() {
            _db.SaveChanges();
        }
        public IEnumerable<User> ReadUsers() {
            return _db.Users;
        }
        public User ReadOneUser(string name) {
            return _db.Users.FirstOrDefault(s => s.Name == name);
        }
        public void SaveUser(User user) {
            _db.Add(user);
            _db.SaveChanges();
        }

        public IEnumerable<Order> ReadOrders(Store store) {
            var s = ReadOneStore(store.Name);
            return s.Orders;
        }

        public Store SelectStore() {
            string input = Console.ReadLine();
            
            return ReadOneStore(input);
        }

        public User SelectUser() {
            string input = Console.ReadLine();

            return ReadOneUser(input);
        }
    }
}