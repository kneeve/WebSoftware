using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EFGetStarted.AspNetCore.NewDb.Models;
using WebApplication1.Data;
using WebApplication1.Models;
/// <summary>
/// Kaelin Hoang
/// Main function for the web application
/// </summary>
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var ccontext = services.GetRequiredService<CourseContext>();
                    var locontext = services.GetRequiredService<LearningOutcomesContext>();
                    DbInitializer.Initialize(ccontext);
                    DbInitializer.InitializeAsync(locontext, services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
