using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Web.Initialise;

namespace AppTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
            // log the app start.
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("App started {Date} date in UTC format ", DateTime.UtcNow);
            Initialise Init = new Initialise();
            if (!Init.Complete)            
            { 
               // opps something failed handler 
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // Initially setting up application logging to windows event log only
            // view video https://www.youtube.com/watch?v=oXNslgIXIbQ for outline on how logging is implemented  

            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    // logging.AddDebug();
                    // logging.AddConsole();
                    logging.AddEventLog();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
