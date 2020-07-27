using PizzaStore.Domain.Models;
using System.Collections.Generic;
using Xunit;
namespace PizzaStore.Testing.Tests
{
    public class PizzaTest
    {
        [Fact]
        public void Test_CreatePizza()
        {
            //arrange
            var sut = new Order();
            string size = "S";
            string crust = "C";
            List<string> toppings = new List<string>{"T"};

            //act
            sut.CreatePizza(size,crust,toppings);

            //assert
            
            Assert.True(sut.Pizzas.Count >= 1);
        }
    }
}