using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public partial class Pizza
    {
        public Pizza()
        {
            Toppings = new HashSet<Toppings>();
        }

        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<Toppings> Toppings { get; set; }
    }
}
