﻿using System;
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
            foreach(var store in _client.Stores) {
                System.Console.WriteLine(store);
            }
        }

        static void PrintAllStoresWithEF() {
            foreach(var store in _sql.ReadStores()) {
                System.Console.WriteLine(store);
            }
        }

        static void UserView() {
            var user = new User();

            PrintAllStoresWithEF();
            user.SelectedStore = _client.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            user.Orders.Last().MakePizza();
            user.Orders.Last().MakePizza();

            Console.WriteLine(user);
        }
    }
}
