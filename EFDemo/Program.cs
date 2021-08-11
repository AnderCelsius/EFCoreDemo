using EFCoreDemo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace EFCoreDemo.UI
{
    class Program : IDesignTimeDbContextFactory<DemoContext>
    {
        //static string connString = ConfigurationManager.ConnectionStrings["DemoContext"].ConnectionString;
        private static IServiceProvider serviceProvider;

        private const string connString = "Data Source=.;Initial Catalog=EFDemoDb;Integrated Security=True";

        static void Main(string[] args)
        {
            ConfigureService();

            DemoContext context = serviceProvider.GetRequiredService<DemoContext>();
            Seeder.SeedData(context).Wait();

            RunApp run = new RunApp();
            run.Start();
            
        }

        static void ConfigureService()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DemoContext>(options => options.UseSqlServer(connString));

            serviceProvider = services.BuildServiceProvider();
        }

        public DemoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            optionsBuilder.UseSqlServer(connString);
            return new DemoContext(optionsBuilder.Options);
        }
    }
}
