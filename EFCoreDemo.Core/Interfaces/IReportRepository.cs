using EFCoreDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Core.Interfaces
{
    public interface IReportRepository
    {
        void PrintCustomers(ICollection<Customer> listOfCustomers);
        void PrintTopFiveDeals(ICollection<Order> orders);
        void PrintHighOrderCustomer(ICollection<Order> orders);
        void PrintSalesReport(ICollection<Order> orders);
    }
}
