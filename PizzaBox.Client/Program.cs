using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean exit = false;

            welcomeBanner();
            while(exit == false)
            {
                exit = primaryLoop();
            }
            Console.WriteLine("Bye");
            
        }
        static void welcomeBanner()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Welcome to the Pizza Box");
            Console.WriteLine("Where we know you are smart enough to use a command line UI");
            Console.WriteLine("");
            Console.WriteLine("Here at Pizza Box we make pizzas you consume.");
            Console.WriteLine("Follow prompt instructions to complete an order");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
        }
        static void displayMainMenu()
        {
            Console.WriteLine("Enter a letter option then press enter to continue");
            Console.WriteLine("Would you like to...");
            Console.WriteLine("A : Add a Pizza");
            Console.WriteLine("B : Complete your current order");
            Console.WriteLine("C : Change User");
            Console.WriteLine("D : Change Store");
            Console.WriteLine("E : Remove Pizza in an Order");
            Console.WriteLine("F : Modify Pizza in an Order");
            Console.WriteLine("G : Checkout With current Order");
            Console.WriteLine("Q : To exit the program");
            Console.WriteLine("");
        }
        static void displayPizzas()
        {
            Console.WriteLine("What type of pizza would you like to add to your order?");
            Console.WriteLine("A: Cheese Pizza | Small,Normal Crust,American&Mozza Cheese, $8");
            Console.WriteLine("B: Pepperoni Pizza | Medium,burned Crust,American Cheese/Pepperoni, $9");
            Console.WriteLine("C: Niche Pizza (Hawaiian Pizza) | Large,stuffed Crust,American Cheese/Pineapple, $10");
            Console.WriteLine("D: Custom Pizza (Advanced users only)| S/M/L,?,American&Mozza Cheese(by default), $25");
            Console.WriteLine("Q: Exit adding pizza");
        }
        static User userLoop()
        {
            string input;
            Console.WriteLine("What is your username?");
            input = acceptInputS();
            return new User(input);
        }
        static Boolean primaryLoop()
        {
            Boolean exit = false;
            Boolean changeUser = true;
            Boolean changeStore = true;
            User user = new User();
            List<Store> stores = new List<Store>{new Store("North Store"), new Store("South Store")};
            Store store = null;
            char input;
            //List<Order> orders = new List<Order>();
            Order currentOrder = null;
            while(exit == false)
            {
                if(currentOrder != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Users orders are");
                    Console.WriteLine("#pizzas, completed");
                    Console.WriteLine("");

                    foreach(var o in user.Orders)
                    {
                        Console.WriteLine(o.toString());
                    }
                    
                }
                if(changeUser == true)
                {
                    user = userLoop();
                    changeUser = false;
                }
                if(changeStore == true)
                {
                    store = storeLoop(stores);
                    changeStore = false;
                }
                displayMainMenu();
                input = acceptInputC();
                if(input.Equals('Q') == false)
                {
                    switch(input)
                    {
                        case 'A':
                            if(currentOrder is null)
                            {
                                user.Orders.Add(store.CreateOrder());
                                currentOrder = user.Orders[user.Orders.Count-1];
                            }
                            currentOrder = pizzaLoop(currentOrder);
                            break;
                        case 'B':
                            completeOrder(user, currentOrder, store);
                            break;
                        case 'C':
                            changeUser = true;
                            break;
                        case 'D':
                            changeStore = true;
                            break;
                        case 'E':
                            if(currentOrder.done == true)
                            {
                                Console.WriteLine("This order cannot be modified. It is completed.");
                            }
                            else
                            {
                                currentOrder = pizzaRemove(currentOrder);
                            }
                            break;
                        case 'F':
                            user.Orders = pizzaChange(user.Orders);
                            break;
                        case 'G':
                            checkout(store, currentOrder, user);
                            exit = true;
                            break;
                        case 'Q':
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("default case");
                            break;
                    }

                }
                else
                {
                    exit = true;
                }
                
            }
            return exit;
        }
        static char acceptInputC()
        {
            char input = ' ';
            string inputTemp;
            char[] inputTempChar;
            Console.Write("Enter option here ->");
            try
            {
                inputTemp = (Console.ReadLine().ToUpper());
                inputTempChar = inputTemp.ToCharArray();
                input = inputTempChar[0];
                bool isNumeric = int.TryParse(input.ToString(), out _);
                while(input.Equals(' ') || (isNumeric == true))
                {
                    Console.WriteLine("Please input non numerics or special characters");
                    Console.Write("Enter option here ->");
                    inputTemp = (Console.ReadLine().ToUpper());
                    inputTempChar = inputTemp.ToCharArray();
                    input = inputTempChar[0];
                }
                Console.WriteLine(input);
                
            }
            catch
            {
                Console.Write("Bad input");
            }
            return input;
        }
        static string acceptInputS()
        {
            string inputTemp = " ";
            Console.Write("Enter option here ->");
            try
            {
                inputTemp = (Console.ReadLine());
                bool isNumeric = int.TryParse(inputTemp, out _);
                while(inputTemp.Equals(" ") || (isNumeric == true))
                {
                    Console.WriteLine("Please input non numerics or special characters");
                    Console.Write("Enter option here ->");
                    inputTemp = (Console.ReadLine());
                    isNumeric = int.TryParse(inputTemp, out _);
                }
                Console.WriteLine(inputTemp);
                
            }
            catch
            {
                Console.Write("Bad input");
            }
            return inputTemp;
        }
        static int acceptInputNumeric()
        {
            string inputTemp = " ";
            Console.Write("Enter option here ->");
            try
            {
                inputTemp = (Console.ReadLine());
                bool isNumeric = int.TryParse(inputTemp, out _);
                while(inputTemp.Equals(" ") || (isNumeric == false))
                {
                    Console.WriteLine("Please input numerics");
                    Console.Write("Enter option here ->");
                    inputTemp = (Console.ReadLine());
                    isNumeric = int.TryParse(inputTemp, out _);
                }
                Console.WriteLine(inputTemp);
                
            }
            catch
            {
                Console.Write("Bad input");
            }
            return int.Parse(inputTemp);
        }
        static Order pizzaLoop(Order order)
        {
            char input = ' ';
            displayPizzas();
            input = acceptInputC();
            Pizza pizza = new Pizza();
            if(input.Equals('Q') == false)
            {
                switch(input)
                {
                    case 'A':
                        pizza = new Pizza("CheesePizza","S","Normal",8.0,new List<string>{"American Cheese","Mozzarella Cheese"});
                        break;
                    case 'B':
                        pizza = new Pizza("PepperoniPizza","M","Burned",9.0,new List<string>{"American Cheese","Pepperoni"});
                        break;
                    case 'C':
                        pizza = new Pizza("NichePizza","S","Stuffed",10.0,new List<string>{"American Cheese","Pinapple"});
                        break;
                    case 'D':
                        pizza = customPizzaLoop();
                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("default case");
                        break;

                }
                order.Pizzas.Add(pizza);
            }
            return order;

        }
        static Pizza customPizzaLoop()
        {
            Boolean toppingsOver = false;
            Console.WriteLine("This sequence will simply input custom information");
            Console.WriteLine("What is the pizza's name?");
            var name = acceptInputS();
            Console.WriteLine("What is the Size of the pizza?");
            var size = acceptInputS();
            Console.WriteLine("What is the Crust of the pizza?");
            var crust = acceptInputS();
            List<string> toppings = new List<string>{"American Cheese","Mozzarella Cheese"};
            char input;
            int toppingIndex = 0;
            var topcounter = 0;
            while(toppingsOver == false || toppings.Count >=5)
            {
                topcounter = 0;
                foreach(var t in toppings)
                {
                    Console.WriteLine(topcounter + ", "+toppingIndex.ToString() + ", "+ t);
                    topcounter++;
                }
                Console.WriteLine("Any more toppings? (A)dd,(R)emove,(D)one, 2 is the least, 5 is the limit");
                input = acceptInputC();
                toppingIndex = 0;
                switch(input)
                {
                    case 'A':
                        Console.WriteLine("Topping name is?");
                        toppings.Add(acceptInputS());
                        break;
                    case 'R':
                        Console.WriteLine("Remove topping of what index");
                        topcounter = 0
                        foreach(var t in toppings)
                        {
                            Console.WriteLine(topcounter + ", "+toppingIndex.ToString() + ", "+ t);
                            topcounter++;
                        }
                        toppings.RemoveAt(acceptInputNumeric());
                        break;
                    case 'D':
                        toppingsOver = true;
                        break;
                }
                
            }
            return new Pizza(name, size, crust, 25.0,toppings);
        }
        static List<Order> pizzaChange(List<Order> orders)
        {
            Console.WriteLine("Which Pizza will you edit?");
            int orderCounter = 0;
            int pizzaCounter = 0;
            Console.WriteLine("Order #, Pizza #, Pizza String");
            foreach(var o in orders)
            {
                foreach(var p in o.Pizzas)
                {
                    Console.WriteLine(orderCounter+", "+pizzaCounter+", "+p.toString());
                    pizzaCounter++;
                }
                orderCounter++;
            }
            pizzaCounter = 0;
            Console.WriteLine("What Order to edit?");
            var orderInput = acceptInputNumeric();
            if(orders[orderInput].done == true)
            {
                Console.WriteLine("This order cannot be modified. It is completed.");
            }
            else
            {
                foreach(var p in orders[orderInput].Pizzas)
                {
                    Console.WriteLine(pizzaCounter+", "+p.toString());
                    pizzaCounter++;
                }
                Console.WriteLine("What Pizza to edit?");
                var pizzaInput = acceptInputNumeric();
                orders[orderInput].Pizzas[pizzaInput] = pizzaEdit(orders[orderInput].Pizzas[pizzaInput]);
            }
            return orders;
        }
        static Pizza pizzaEdit(Pizza pizza)
        {
            Console.WriteLine("You are remaking a pizza. Enter old data of stuff you dont want to change.");
            Console.WriteLine(pizza.toString());
            pizza = customPizzaLoop();
            return pizza;
        }
        static Store storeLoop(List<Store> stores)
        {
            Console.WriteLine("Which store are you ordering from?");
            int counter = 0;
            foreach(var s in stores)
            {
                Console.WriteLine(counter + " :" + s.Name);
                counter++;
            }
            Console.WriteLine("Select a store's index");
            var input = acceptInputNumeric();
            return stores[input];
        }
        static void checkout(Store store, Order order, User user)
        {
            PizzaBox.Storing.Repositories.PizzaRepository pr = new PizzaBox.Storing.Repositories.PizzaRepository();
            if((order.orderPrice() <= (double)order.priceLimit) && (order.Pizzas.Count <= order.pizzaLimit))
            {
                Console.WriteLine("Conditions met to checkout");
                store.Orders.Add(order);
                //user.Orders.Add(order);
                // pr.CreateStore(store);
                // pr.CreateUser(user);
                // pr.CreateOrder(order, pr.FindUserId(user.name), pr.FindStoreId(store.Name));
            }
            else
            {
                Console.WriteLine("Conditions NOT met to checkout");
                if((order.done == true))
                {
                    Console.WriteLine("Confirm the order is done in the main menu");
                }
                if(order.orderPrice() <= (double)order.priceLimit)
                {
                    Console.WriteLine("Edit your order to make it less then $250");
                }
                if(order.Pizzas.Count <= order.pizzaLimit)
                {
                    Console.WriteLine("Edit your order to have less then 50 pizzas");
                }
            }

            
        }
        static void completeOrder(User user, Order order, Store store)
        {
            order.completed();
            user.orderHistory.Add("Order at " + DateTime.Now.ToString() + " with " + order.Pizzas.Count.ToString() + " Pizzas");
        }
        static Order pizzaRemove(Order orders)
        {
            Console.WriteLine("Which pizza to remove?");
            Console.WriteLine("Index #, Pizza info");
            int oInt = 0;
            foreach(var p in orders.Pizzas)
            {
                Console.WriteLine(oInt + ", " + p.toString());
                oInt++;
            }
            int input = acceptInputNumeric();
            orders.Pizzas.RemoveAt(input);
            return orders;
        }
    }
}
