using EFCoreDemo.Database;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFCoreDemo.UI
{
    class Program : IDesignTimeDbContextFactory<DemoContext>
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void ConfigureService()
        {
            var services = new ServiceCollection();
        }

        public DemoContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
