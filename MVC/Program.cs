using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LibTP;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace TPGroupeCPD
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = CreateWebHostBuilder(args).Build();
            var dbContext = (AppDbContext)builder.Services.CreateScope().ServiceProvider.GetRequiredService(typeof(AppDbContext));
            dbContext.Database.EnsureCreated();

            builder.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
