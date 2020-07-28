using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public partial class Store
    {
        public Store()
        {
            Order = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
