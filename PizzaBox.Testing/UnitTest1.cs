using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing
{
    public class OrderTest
    {
        [Fact]
        public void Test_CreatePizza()
        {
            // arrange
            PizzaBox.Storing.Repositories.PizzaRepository pr = new PizzaBox.Storing.Repositories.PizzaRepository();
            User user = new User("test");
            Store store = new Store("North");
            var order = new Order();
            order.completed();
            string size = "S";
            string crust = "Normal";
            
            List<string> toppings = new List<string>{"topping"};
            //action
            order.CreatePizza("test",size, crust,8.0,toppings);
            pr.CreateStore(store);
            pr.CreateUser(user);
            pr.CreateOrder(order, pr.FindUserId(user.name), pr.FindStoreId(store.Name));

            //assert
            var test = pr.ReadAllOrders();
            Assert.True(test.Count > 0);
        }
    }
}