using System.Collections.Generic;
using System;
namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public List<Order> Orders { get; set; }
    public string Name { get; set; }
    public Store(string name)
    {
      this.Name = name;
    }
    public Order CreateOrder()
    {
      return new Order();
    }
    public void displayOrders()
    {
      Console.WriteLine("#OfPizzas, completed or naw");
      foreach(var o in Orders)
      {
        Console.WriteLine(o.toString());
      }
    }
    
  }
}