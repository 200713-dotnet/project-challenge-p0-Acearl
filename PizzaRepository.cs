// using PizzaBox.Domain.Models;
// using System.Linq;
// using domain = PizzaBox.Domain.Models;

// namespace PizzaBox.Storing.Repositories
// {
//     public class PizzaRepository
//     {
//         private PizzaBoxDbContext _db = new PizzaBoxDbContext();
//         public void Create(domain.Pizza pizza)
//         {
//             var newPizza = new Pizza();
            
//             newPizza.name = pizza.name;
//             newPizza.size = pizza.size;
//             newPizza.crust = pizza.crust;
            
//             _db.Pizza.Add(newPizza);
//             _db.SaveChanges();
//         }
//         public IEnumerable<domain.Pizza> ReadAll()
//         {
//             var domainPizzaList = new List<domain.Pizza>();

//             foreach(var item in _db.Pizza.ToList())
//             {
//                 domainPizzaList.Add(new domain.Pizza()
//                 {
                   
                    
//                     name = new String item.name;
//                     size = new String item.size;
//                     crust = new String item.crust;
//                     crust = new List<string> item.toppings;
//                 }
//             }
//             return _db.Pizza.ToList();
//         }
//         public void Update();
//         public void Delete();
//     }
// }

