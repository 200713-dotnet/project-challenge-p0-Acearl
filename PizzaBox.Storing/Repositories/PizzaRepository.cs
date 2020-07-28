using PizzaBox.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using domain = PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaRepository
    {
        private PizzaBoxDbContext _db = new PizzaBoxDbContext();
        public void CreatePizza(domain.Pizza pizza, int orderId)
        {
            var dbPizza = new Pizza();
            
            dbPizza.Name = pizza.name;
            dbPizza.Size = pizza.size;
            dbPizza.Crust = pizza.crust;
            dbPizza.OrderId = orderId;
            foreach(var t in pizza.Toppings)
            {
                CreateTopping(t,dbPizza.PizzaId);
            }
            _db.Pizza.Add(dbPizza);
            _db.SaveChanges();
        }
        public void CreateTopping(string passedTopping, int pizzaId)
        {
            var topping = new Toppings();
            
            topping.Name = passedTopping;
            
            _db.Toppings.Add(topping);
        }
        public void CreateOrder(domain.Order order, int userId, int storeId)
        {
            var dbOrder = new Order();
            
            dbOrder.UserId = userId;
            dbOrder.StoreId = storeId;
            foreach(var p in order.Pizzas)
            {
                CreatePizza(p, dbOrder.OrderId);
            }
            _db.Order.Add(dbOrder);
            _db.SaveChanges();
        }
        public void CreateUser(domain.User user)
        {
            var dbUser = new User();
            
            dbUser.Name = user.name;
            
            _db.User.Add(dbUser);
            _db.SaveChanges();
        }
        public void CreateStore(domain.Store store)
        {
            var dbStore = new Store();
            
            dbStore.Name = store.Name;
            
            _db.Store.Add(dbStore);
            _db.SaveChanges();
        }
        // public IEnumerable<domain.Pizza> ReadAll()
        // {
        //     var domainPizzaList = new List<domain.Pizza>();

        //     foreach(var item in _db.Pizza.ToList())
        //     {
        //         domainPizzaList.Add(new domain.Pizza()
        //         {
                   
                    
        //             name = new String item.Name;
        //             size = new String item.Size;
        //             crust = new String item.crust;
        //             crust = new List<string> item.toppings;
        //         }
        //     }
        //     return _db.Pizza.ToList();
        // }
        // public void Update();
        // public void Delete();
    }
}

