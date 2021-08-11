using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreDemo.Model
{
    public class ProductSupplier
    {
        [Required]
        [MaxLength(125)]
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [MaxLength(125)]
        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
