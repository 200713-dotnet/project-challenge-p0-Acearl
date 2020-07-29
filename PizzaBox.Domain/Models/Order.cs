using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public Boolean done { get; set; } = false;
    public int priceLimit = 250;
    public int pizzaLimit = 50;
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public DateTime DateOrdered { get; set; }
    public Boolean completed()
    {
      done = true;
      return done;
    }
    public void CreatePizza()
    {
      Pizzas.Add(new Pizza());
    }
    public void CreatePizza(string name,string size, string crust, double price, List<string> toppings)
    {
      this.Pizzas.Add(new Pizza(name,size,crust,price,toppings));
    }
    public double orderPrice()
    {
      double price = 0.0;
      foreach(var p in Pizzas)
      {
        price += p.price;
      }
      return price;
    }
    public void displayPizzas()
    {
      Console.WriteLine("Name, Size, Crust, Topping/Topping");
      foreach(var p in Pizzas)
      {
        Console.WriteLine(p.toString());
      }
    }
    public string toString()
    {
      string output = "";
      output += Pizzas.Count.ToString() +", " + done.ToString();
      return output;
    }
  }
  
}