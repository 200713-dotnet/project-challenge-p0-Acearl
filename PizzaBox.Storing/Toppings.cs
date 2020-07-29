using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public partial class Toppings
    {
        public int ToppingId { get; set; }
        public int PizzaId { get; set; }
        public string Name { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
