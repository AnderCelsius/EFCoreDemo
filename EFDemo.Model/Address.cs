using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Address
    {
        public Guid Id { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
    }
}
