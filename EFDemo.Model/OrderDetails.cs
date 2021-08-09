using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Model
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public ICollection<Product> Products { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public bool Fulfilled { get; set; }
    }
}
