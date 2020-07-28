using System.Collections.Generic;

namespace PizzaBox.Domain.Models
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
    public Pizza(string name, string size, string crust, double price, List<string> toppings)
    {
      this.name = name;
      this.size = size;
      this.crust = crust;
      this.price = price;
      this.Toppings = toppings;
    }

    public Pizza()
    {
    }

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