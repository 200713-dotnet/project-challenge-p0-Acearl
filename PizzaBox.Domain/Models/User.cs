using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    
    public List<string> orderHistory { get; set; }
    public List<Order> Orders { get; set; }
    public string name { get; set; }
    public User()
    {

    }
    public User(string name)
    {
      this.name = name;
    }
    public void updateOrderHistory(string line)
    {
      orderHistory.Add(line);
    }
    
  }
}