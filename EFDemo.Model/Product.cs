using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Supplier Supplier { get; set; }
    }
}
