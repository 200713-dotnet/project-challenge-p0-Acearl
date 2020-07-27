using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    private const int toppingLimit = 5;
    private const int toppingMin = 2;
    public List<string> Toppings { get; set; }
    public string name { get; set; }
    public string size { get; set; }
    public string crust { get; set; }
    public double price {get; set;}

    public string toString()
    {
      string output = "";
      output = name + ", " + size + ", " + crust + ", " + price + ", ";
      foreach(var t in Toppings)
      {
        output += t + "/";
      }
      return output;
    }
  }
}