using System;
using System.Collections.Generic;

namespace EFCoreDemo.Model
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
