using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        private static readonly ClientSingleton _client = ClientSingleton.Instance;
        private static readonly SqlClient _sql = new SqlClient();

        public Program() {
            
        }
        static void Main(string[] args)
        {
            UserView();
        }

        static void PrintAllStores() {
            Console.WriteLine("Available stores:");
            foreach(var store in _client.Stores) {
                System.Console.WriteLine(store);
            }
        }

        static void PrintAllStoresWithEF() {
            Console.WriteLine("Available stores:");
            foreach(var store in _sql.ReadStores()) {
                System.Console.WriteLine(store);
            }
        }

        static void PrintAllUsers() {
            Console.WriteLine("Available users:");
            foreach(var user in _client.Users) {
                System.Console.WriteLine(user);
            }
        }

        static void PrintAllUsersWithEF() {
            Console.WriteLine("Available users:");
            foreach(var user in _sql.ReadUsers()) {
                System.Console.WriteLine(user);
            }
        }

        static void UserView() {
            PrintAllUsersWithEF();
            Console.WriteLine("Please input the index of the user you want.");
            User user;
            try {
                user = _client.SelectUser();
            }
            catch {
                Console.WriteLine("There's no user in that location, fool!");
                user = new User();
                //return;
            }

            PrintAllStoresWithEF();
            Console.WriteLine("Please input the name of the store you want.");
            user.SelectedStore = _sql.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            user.Orders.Last().MakePizza();
            user.Orders.Last().MakePizza();
            _sql.Update();

            Console.WriteLine(user);
        }
    }
}
