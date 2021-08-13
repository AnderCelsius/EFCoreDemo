using EFCoreDemo.Commons;
using EFCoreDemo.Core.Interfaces;
using EFCoreDemo.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EFCoreDemo.Core
{
    public class ReportRepository : IReportRepository
    {
        public void PrintCustomers(ICollection<Customer> listOfCustomers)
        {
            var customersByCity = listOfCustomers
                    .OrderBy(customer => customer.Address.City)
                    .Take(10)
                    .Select(customer => new[]
                    {
                        customer.FirstName + " " + customer.LastName,
                        customer.Email,
                        customer.Address.City
                    });

            var header = new[] { "Customer Name", "Email ID", "City" };
            Print(header, customersByCity);
        }

        public void PrintTopFiveDeals(ICollection<Order> orders)
        {
            var customersWithHighestOrderAmount = orders
                .OrderByDescending(o => o.TotalAmount)
                .Take(5)
                .Select(o => new[]
                {
                    o.OrderDate.ToShortDateString(),
                    o.Customer.FirstName + " " + o.Customer.LastName,
                    o.Shipper.CompanyName,
                    o.Status,
                    o.TotalAmount.ToString()
                });
            string[] header = new[] { "Order Date", "Customer Name", "Shipper", "Order Status", "Total Amount" };
            Print(header, customersWithHighestOrderAmount);
        }

        public void PrintHighOrderCustomer(ICollection<Order> orders)
        {
            var customersWithHighestOrderAmount = orders
                .Where(o => o.TotalAmount > 100000)
                .OrderBy(o => o.Customer.FirstName)
                .Take(10)
                .Select(o => new[]
                {
                    o.Customer.FirstName + " " + o.Customer.LastName,
                    o.Customer.Email,
                    o.Customer.Address.City,
                    o.Customer.Address.State,
                    o.TotalAmount.ToString()
                });
            string[] header = new[] { "Name", "Email", "City", "State", "Total Amount" };
            Print(header, customersWithHighestOrderAmount);
        }

        /// <summary>
        /// Display 10 sales record.
        /// </summary>
        /// <param name="orders"></param>
        public void PrintSalesReport(ICollection<Order> orders)
        {
            var sales = orders
                .Take(10)
                .Select(s =>
                s.OrderDetails.Select(od => new string[]{
                    s.OrderDate.ToShortDateString(),
                    od.Product.ProductName,
                    od.Product.UnitPrice.ToString(),
                    od.Quantity.ToString(),
                    (od.Quantity * od.Product.UnitPrice).ToString("N1", CultureInfo.InvariantCulture)
                }).Take(1));
            string[] header = new[] { "Order Date", "Product Name", "Unit Price", "Quantity", "Total Amount" };

            List<string[]> salesReport = new List<string[]>();
            foreach (var item in sales)
            {
                salesReport.AddRange(item);
            }
            salesReport.OrderBy(m => m[0]);

            Print(header, salesReport);
        }

        private static void Print(string[] header, IEnumerable<string[]> data)
        {
            PrintTable.PrintLine();
            PrintTable.PrintRow(header);
            PrintTable.PrintLine();
            foreach (var item in data)
            {
                PrintTable.PrintRow(item);
                PrintTable.PrintLine();

            }
        }
    }

}
