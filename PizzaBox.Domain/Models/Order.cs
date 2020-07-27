using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    Boolean completed { get; set; }
    private const int priceLimit = 250;
    private const int pizzaLimit = 50;
    public List<Pizza> Pizzas { get; set; }
    public DateTime DateOrdered { get; set; }

    public void CreatePizza()
    {
      Pizzas.Add(new Pizza());
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
    public void toString()
    {

    }
  }
  
}