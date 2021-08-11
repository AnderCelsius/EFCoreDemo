using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Supplier
    {
        [StringLength(125)]
        public string Id { get; set; }
        [Required]
        [StringLength(125)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}
