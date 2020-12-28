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
                System.Console.WriteLine(user.Name);
            }
        }

        static void UserView() {
            PrintAllUsersWithEF();
            Console.WriteLine("Please input the name of the user you want.");
            User user;
            try {
                user = _sql.SelectUser();
            }
            catch {
                Console.WriteLine("That's not a valid user, fool!");
                return;
            }

            PrintAllStoresWithEF();
            Console.WriteLine("Please input the name of the store you want.");
            try {
                user.SelectedStore = _sql.SelectStore();
            }
            catch {
                Console.WriteLine("That's not a valid store, fool!");
                return;
            }

            Console.WriteLine("Please select the type of pizza you'd like to order.");
            Console.WriteLine("Basic: $19.99");
            Console.WriteLine("Meat Lovers: $29.99");
            Console.WriteLine("Vegetarian: $24.99");
            Console.WriteLine("Custom");
            Console.WriteLine("Or, type 'userorder' to view your own order history.");
            Console.WriteLine("Or, type 'storeorder' to view the store's order history.");

            string input = Console.ReadLine().ToUpper();

            switch(input) {
                case "BASIC":
                Console.WriteLine("You have selected the basic pizza.");
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                user.Orders.Last().MakePizza("normal", "medium", new List<string>{"cheese", "pepperoni"});
                break;
                case "MEAT LOVERS":
                Console.WriteLine("You have selected the meat lovers pizza.");
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                user.Orders.Last().MakePizza("normal", "medium", new List<string>{"cheese", "pepperoni", "bacon", "ham"});
                break;
                case "VEGETARIAN":
                Console.WriteLine("You have selected the vegetarian pizza.");
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                user.Orders.Last().MakePizza("normal", "medium", new List<string>{"cheese", "pineapple", "onion"});
                break;
                case "CUSTOM":
                Console.WriteLine("You have decided to build your own pizza.");
                break;
                case "USERORDER":
                Console.WriteLine("You have decided to view your own order history.");
                break;
                case "STOREORDER":
                Console.WriteLine("You have decided to view the store's order history.");
                break;
                default:
                Console.WriteLine("That's not a valid option, fool!");
                return;
            }

            _sql.Update();
        }
    }
}
