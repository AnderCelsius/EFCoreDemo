using EFCoreDemo.Core;
using EFCoreDemo.Core.AccessFactory;
using EFCoreDemo.Core.Interfaces;
using EFCoreDemo.Database;
using EFCoreDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EFCoreDemo.UI
{
    public class RunApp
    {
        readonly IReportRepository _report;
        DemoContext context;

        public RunApp(IServiceProvider serviceProvider)
        {
            _report = DataFactory.GetReportRepository();
            context = serviceProvider.GetRequiredService<DemoContext>();
        }
        public void Start()
        {
            IList<Order> orders;
            IList<Customer> customers;

            ReadFromDB(out orders, out customers);

            do
            {
                string userInput = FetchUserInput();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine();
                        _report.PrintSalesReport(orders);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine();
                        _report.PrintHighOrderCustomer(orders);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine();
                        _report.PrintTopFiveDeals(orders);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine();
                        _report.PrintCustomers(customers);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please select a valid option");
                        break;
                }
                if (userInput.ToLower() == "exit")
                    break;
            } while (true);
        }

        private void ReadFromDB(out IList<Order> orders, out IList<Customer> customers)
        {
            GetAllOrders(context, out orders);
            GetCustomers(context, out customers);
        }

        public static void GetCustomers(DemoContext context, out IList<Customer> customers)
        {
            customers = context.Customers
              .Include(c => c.Address)
              .ToList();
        }

        private string FetchUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Celsius");
            Console.WriteLine();
            Console.WriteLine("Press 1 to Display Sales Report");
            Console.WriteLine("Press 2 to Display Customers with High Order Amount");
            Console.WriteLine("Press 3 to Display Top Five Deals");
            Console.WriteLine("Press 4 to DIsplay Customers Grouped by City");
            Console.WriteLine("Type exit to quit");
            Console.WriteLine();
            Console.Write(">> ");
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static void GetAllOrders(DemoContext context, out IList<Order> orders)
        {
            orders = context.Orders
              .Include(x => x.OrderDetails)
              .ThenInclude(oi => oi.Product)
              .Include(x => x.Customer)
              .ThenInclude(c => c.Address)
              .Include(s => s.Shipper)
              .ToList();
        }


    }
}
