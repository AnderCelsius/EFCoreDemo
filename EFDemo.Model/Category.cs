using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
