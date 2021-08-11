using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Address
    {
        public string Id { get; set; }
        [Required]
        [StringLength(10)]
        public string HouseNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        public string PostalCode { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
