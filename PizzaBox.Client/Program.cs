using System;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            welcomeBanner();
            primaryLoop();
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
        static void primaryLoop()
        {
            Boolean exit = false;
            string input;
            while(exit != true)
            {
                displayMainMenu();
                input = acceptInput();
                if(input.Equals("Q") == false)
                {
                    
                }
            }
        }
        static string acceptInput()
        {
            string input = "";
            Console.Write("Enter option here ->");
            try
            {
                input = Char.ConvertFromUtf32(Console.Read()).ToUpper();
                Console.Write(input);
                //char.Parse(input);
            }
            catch
            {

            }
            finally
            {
                
            }
            return input;
        }
    }
}
