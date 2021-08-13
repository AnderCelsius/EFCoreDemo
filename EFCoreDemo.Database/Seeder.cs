using EFCoreDemo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Database
{
    public class Seeder
    {
        public static async Task SeedData(DemoContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.Customers.Any())
                {
                    var customerData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\Customers.json");
                    var listOfCustomers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                    await context.Customers.AddRangeAsync(listOfCustomers);
                }
                if (!context.Suppliers.Any())
                {
                    var supplierData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\Suppliers.json");
                    var listOfSuppliers = JsonConvert.DeserializeObject<List<Supplier>>(supplierData);
                    await context.Suppliers.AddRangeAsync(listOfSuppliers);
                }
                if (!context.Shippers.Any())
                {
                    var shippersData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\Shippers.json");
                    var listOfShippers = JsonConvert.DeserializeObject<List<Shipper>>(shippersData);
                    await context.Shippers.AddRangeAsync(listOfShippers);
                }
                if (!context.Categories.Any())
                {
                    var categoriesData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\Categories.json");
                    var listOfCategories = JsonConvert.DeserializeObject<List<Category>>(categoriesData);
                    await context.Categories.AddRangeAsync(listOfCategories);
                }
                if (!context.OrderDetails.Any())
                {
                    var orderDetailsData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\OrderDetails.json");
                    var listOfOrders = JsonConvert.DeserializeObject<List<OrderDetails>>(orderDetailsData);
                    await context.OrderDetails.AddRangeAsync(listOfOrders);
                }
                if (!context.Orders.Any())
                {
                    var ordersData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\Orders.json");
                    var orders = JsonConvert.DeserializeObject<List<Order>>(ordersData);
                    await context.Orders.AddRangeAsync(orders);
                }
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText(@"C:\Users\hp\source\repos\EFDemo\EFCoreDemo.Database\JsonFiles\Products.json");
                    var listOfProducts = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products.AddRangeAsync(listOfProducts);
                }
                
                
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
