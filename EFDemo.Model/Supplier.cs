using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string URL { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
