using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Shipper
    {
        [StringLength(125)]
        public String Id { get; set; }
        [Required]
        [StringLength(125)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
