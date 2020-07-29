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
            _db.Pizza.Add(dbPizza);
            System.Console.WriteLine("Pizza info");
            //System.Console.WriteLine(dbPizza.PizzaId);
            foreach(var t in pizza.Toppings)
            {
                CreateTopping(t,dbPizza.PizzaId);
            }
        }
        public void CreateTopping(string passedTopping, int pizzaId)
        {
            var topping = new Toppings();
            //topping.PizzaId = pizzaId + 1;
            topping.Name = passedTopping;
            System.Console.WriteLine("Topping info");
            System.Console.WriteLine(topping.PizzaId);
            System.Console.WriteLine(topping.ToppingId);
            _db.Toppings.Add(topping);
        }
        public void CreateOrder(domain.Order order, int userId, int storeId)
        {
            var dbOrder = new Order();
            dbOrder.UserId = (userId + 1);
            dbOrder.StoreId = (storeId + 1);
            dbOrder.Done = order.done;
            dbOrder.DateOrdered = System.DateTime.Now;
            //dbOrder.OrderId = dbOrder.OrderId + 1;
            
            _db.Order.Add(dbOrder);
            _db.SaveChanges();
            System.Console.WriteLine("FRUSTRATION");
            System.Console.WriteLine(ReadAllOrders().Last().);
            foreach(var p in order.Pizzas)
            {
                CreatePizza(p, (_db.Order.ToList().ElementAt(-1).UserId));
            }
            _db.SaveChanges();
            
        }
        public void CreateUser(domain.User user)
        {
            var dbUser = new User();
            var userlist = ReadAllUsers();
            var userNameList = new List<string>();
            foreach(var u in userlist)
            {
                userNameList.Add(u.name);
            }
            if(userNameList.Contains(user.name))
            {

            }
            else
            {
                dbUser.Name = user.name;
                _db.User.Add(dbUser);
            }
            _db.SaveChanges();
        }
        public void CreateStore(domain.Store store)
        {
            var dbStore = new Store();
            var storelist = ReadAllStores();
            var storeNameList = new List<string>();
            foreach(var s in storelist)
            {
                storeNameList.Add(s.Name);
            }
            if(storeNameList.Contains(store.Name))
            {

            }
            else
            {
                dbStore.Name = store.Name;
                _db.Store.Add(dbStore);
            }
            
            _db.SaveChanges();
        }
        public int FindStoreId(string targetName)
        {
            var storeList = ReadAllStores();
            var storeNames = new List<string>();
            foreach(var s in storeList)
            {
                storeNames.Add(s.Name);
            }
            return storeNames.IndexOf(targetName);
        }
        public int FindUserId(string targetName)
        {
            var userList = ReadAllUsers();
            var userNames = new List<string>();
            foreach(var u in userList)
            {
                userNames.Add(u.name);
            }
            return userNames.IndexOf(targetName);
        }
        public List<domain.User> ReadAllUsers()
        {
            var userList = new List<domain.User>();
            foreach(var item in _db.User.ToList())
            {
                userList.Add(new domain.User(item.Name));
            }
            return userList;
        }
        public List<domain.Store> ReadAllStores()
        {
            var storeList = new List<domain.Store>();
            foreach(var item in _db.Store.ToList())
            {
                storeList.Add(new domain.Store(item.Name));
            }
            return storeList;
        }
        public IEnumerable<domain.Order> ReadAllOrders()
        {
            var domainPizzaList = new IEnumerable<List>();
            foreach(var item in _db.Store.ToList())
            {
                storeList.Add(new domain.Store(item.Name));
            }
            return domainPizzaList;
        }
        // public IEnumerable<domain.Pizza> ReadAllOrders()
        // {
        //     var domainPizzaList = new List<domain.Pizza>();

        //     foreach(var item in _db.Pizza.ToList())
        //     {
        //         domainPizzaList.Add(new domain.Pizza()
        //         {
                   
                    
        //             name = item.Name;
        //             size = new String item.Size;
        //             crust = item.Crust;
        //             crust = new List<string> item.toppings;
        //         }
        //     }
        //     return _db.Pizza.ToList();
        // }
        // public void Update();
        // public void Delete();
    }
}

