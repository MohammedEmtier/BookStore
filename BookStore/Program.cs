using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Models;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Webhost = CreateHostBuilder(args).Build();
            RunMigration(Webhost);
            Webhost.Run();
        }

        private static void RunMigration(IHost webhost)
        {
            using (var socpe = webhost.Services.CreateScope())
            {
                var db = socpe.ServiceProvider.GetRequiredService<BookStoreDbContext>();
                db.Database.Migrate();
            }
          
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
