using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean exit = false;
            Boolean changeUser = false;
            User user;
            welcomeBanner();
            while(exit == false)
            {
                userLoop();
                while(changeUser == false)
                {
                    primaryLoop();
                }
                
            }
            
        }
        static void welcomeBanner()
        {
            Console.WriteLine("Welcome to Pizza Box");
            Console.WriteLine("Where we know you are smart enough to use a command line UI");
            Console.WriteLine("");
            Console.WriteLine("Here at Pizza Box we make pizzas you consume.");
            Console.WriteLine("Follow prompt instructions to complete an order");
            Console.WriteLine("");
        }
        static void displayMainMenu()
        {
            Console.WriteLine("Enter a number option then press enter to continue");
            Console.WriteLine("Would you like to...");
            Console.WriteLine("A : Add a Pizza");
            Console.WriteLine("B : Complete your order");
            Console.WriteLine("Q : To exit the program");
            Console.WriteLine("");
        }
        static void displayPizzas()
        {
            Console.Write("What type of pizza would you like to add to your order?");
            Console.Write("A: Cheese Pizza");
            Console.Write("B: Pepperoni Pizza");
            Console.Write("C: Niche Pizza (Hawaiian Pizza)");
            Console.Write("D: Load Pizza from XML file");
            Console.Write("Q: Exit adding pizza");
        }
        static User userLoop()
        {
            return user;
        }
        static void primaryLoop(User user)
        {
            Boolean exit = false;
            char input;
            
            while(exit == false)
            {
                displayMainMenu();
                input = acceptInput();
                if(input.Equals('Q') == false)
                {
                    switch(input)
                    {
                        case 'A':
                            pizzaLoop();
                            break;
                        case 'B':
                            completeOrder();
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
        }
        static char acceptInput()
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
        static Order pizzaLoop(Order order)
        {
            char input = ' ';
            displayPizzas();
            input = acceptInput();
            if(input.Equals('Q') == false)
            {
                switch(input)
                {
                    case 'A':
                        break;
                    case 'B':
                        break;
                    case 'C':
                        break;
                    case 'D':
                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("default case");
                        break;

                }
            }

        }
        static void completeOrder()
        {

        }
    }
}
