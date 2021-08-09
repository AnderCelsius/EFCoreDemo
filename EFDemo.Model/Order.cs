using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public bool Freight { get; set; }
        public double SalesTax { get; set; }
        public double TotalAmount { get; set; }
        public bool Paid { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequireDate { get; set; }
        public DateTime TimeStamp { get; set; }
        
    }
}
