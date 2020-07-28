using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public partial class Order
    {
        public Order()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public byte[] Done { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateOrdered { get; set; }

        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
