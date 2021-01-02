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
            Console.WriteLine("Custom: $9.99 before customization");
            Console.WriteLine("Or, type 'userorder' to view your own order history.");
            Console.WriteLine("Or, type 'storeorder' to view the store's order history.");

            string input = Console.ReadLine().ToUpper();

            switch(input) {
                case "BASIC":
                Console.WriteLine("You have selected the basic pizza.");
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                user.Orders.Last().MakePizza("NORMAL", "MEDIUM", new List<string>{"cheese", "pepperoni"});
                break;
                case "MEAT LOVERS":
                Console.WriteLine("You have selected the meat lovers pizza.");
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                user.Orders.Last().MakePizza("NORMAL", "MEDIUM", new List<string>{"cheese", "pepperoni", "bacon", "ham"});
                break;
                case "VEGETARIAN":
                Console.WriteLine("You have selected the vegetarian pizza.");
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                user.Orders.Last().MakePizza("NORMAL", "MEDIUM", new List<string>{"cheese", "pineapple", "onion"});
                break;
                case "CUSTOM":
                Console.WriteLine("You have decided to build your own pizza.");
                Console.WriteLine("Please select a size.");
                Console.WriteLine("Normal: No price change");
                Console.WriteLine("Large: +$5.00");
                Console.WriteLine("Small: -$5.00");
                string size = Console.ReadLine().ToUpper();
                switch(size) {
                    case "NORMAL":
                    Console.WriteLine("You have selected a normal pizza.");
                    break;
                    case "LARGE":
                    Console.WriteLine("You have selected a large pizza.");
                    break;
                    case "SMALL":
                    Console.WriteLine("You have selected a small pizza.");
                    break;
                    default:
                    Console.WriteLine("That's not a valid size, fool!");
                    return;
                }
                Console.WriteLine("Please select a crust.");
                Console.WriteLine("Normal: No price change");
                Console.WriteLine("Cheese: +$5.00");
                string crust = Console.ReadLine().ToUpper();
                switch(crust) {
                    case "NORMAL":
                    Console.WriteLine("You have selected a normal crust.");
                    break;
                    case "CHEESE":
                    Console.WriteLine("You have selected a cheese crust.");
                    break;
                    default:
                    Console.WriteLine("That's not a valid crust, fool!");
                    return;
                }
                bool exit = false;
                bool cheese = false;
                bool pepperoni = false;
                bool bacon = false;
                bool ham = false;
                bool pineapple = false;
                bool onion = false;
                int toppingCount = 0;

                string input2;
                while(exit == false) {
                    Console.WriteLine("Please select two to five toppings (+$5.00 each).");
                    if(cheese == false) Console.WriteLine("Extra Cheese: Off");
                    else Console.WriteLine("Extra Cheese: On");
                    if(pepperoni == false) Console.WriteLine("Pepperoni: Off");
                    else Console.WriteLine("Pepperoni: On");
                    if(bacon == false) Console.WriteLine("Bacon: Off");
                    else Console.WriteLine("Bacon: On");
                    if(ham == false) Console.WriteLine("Ham: Off");
                    else Console.WriteLine("Ham: On");
                    if(pineapple == false) Console.WriteLine("Pineapple: Off");
                    else Console.WriteLine("Pineapple: On");
                    if(onion == false) Console.WriteLine("Onion: Off");
                    else Console.WriteLine("Onion: On");
                    if(toppingCount >= 2 && toppingCount <= 5) Console.WriteLine("Type 'done' to finish.");
                    input2 = Console.ReadLine().ToUpper();
                    switch(input2) {
                        case "CHEESE":
                        if(cheese == true) {
                            cheese = false;
                            toppingCount--;
                        }
                        else {
                            cheese = true;
                            toppingCount++;
                        }
                        break;
                        case "PEPPERONI":
                        if(pepperoni == true) {
                            pepperoni = false;
                            toppingCount--;
                        }
                        else {
                            pepperoni = true;
                            toppingCount++;
                        }
                        break;
                        case "BACON":
                        if(bacon == true) {
                            bacon = false;
                            toppingCount--;
                        }
                        else {
                            bacon = true;
                            toppingCount++;
                        }
                        break;
                        case "HAM":
                        if(ham == true) {
                            ham = false;
                            toppingCount--;
                        }
                        else {
                            ham = true;
                            toppingCount++;
                        }
                        break;
                        case "PINEAPPLE":
                        if(pineapple == true) {
                            pineapple = false;
                            toppingCount--;
                        }
                        else {
                            pineapple = true;
                            toppingCount++;
                        }
                        break;
                        case "ONION":
                        if(onion == true) {
                            onion = false;
                            toppingCount--;
                        }
                        else {
                            onion = true;
                            toppingCount++;
                        }
                        break;
                        case "DONE":
                        if(toppingCount >= 2 && toppingCount <= 5) exit = true;
                        else Console.WriteLine("You must have between two and five toppings.");
                        break;
                        default:
                        Console.WriteLine("That's not a valid topping, fool!");
                        break;
                    }
                }
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                List<string> toppingList = new List<string>();
                if(cheese == true) toppingList.Add("cheese");
                if(pepperoni == true) toppingList.Add("pepperoni");
                if(bacon == true) toppingList.Add("bacon");
                if(ham == true) toppingList.Add("ham");
                if(pineapple == true) toppingList.Add("pineapple");
                if(onion == true) toppingList.Add("onion");
                user.Orders.Last().MakePizza(crust, size, toppingList);
                break;
                case "USERORDER":
                Console.WriteLine("You have decided to view your own order history.");
                Console.WriteLine(user.Orders);
                break;
                case "STOREORDER":
                Console.WriteLine("You have decided to view the store's order history.");
                Console.WriteLine(user.SelectedStore.Orders);
                break;
                default:
                Console.WriteLine("That's not a valid option, fool!");
                return;
            }

            _sql.Update();
        }
    }
}
