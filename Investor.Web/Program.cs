using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Investor.Repository;
using Investor.Service;
using Microsoft.AspNetCore.Identity;

namespace Investor.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {

                    var context = services.GetService<NewsContext>();
                    var signInManager = services.GetService<SignInManager<UserEntity>>();
                    var userManager = services.GetService<UserManager<UserEntity>>();
                    var roleManager = services.GetService<RoleManager<IdentityRole>>();
                    SampleData.Initialize(context, signInManager, userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseUrls("http://localhost:6969")
            .UseStartup<Startup>()
            .Build();
    }
}
