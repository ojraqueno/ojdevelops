using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace auditing_changes_with_entity_framework
{
    internal class Program
    {
        private static IConfiguration _configuration;
        private static IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            BuildConfiguration();
            ConfigureServices();

            using (var db = new ApplicationDbContext())
            {
                db.Persons.Add(new Person
                {
                    FullName = "John Smith",
                    DateOfBirth = DateTime.Now
                });

                db.SaveChanges();
            }

            Console.WriteLine("Hello World!");
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(_configuration);

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}