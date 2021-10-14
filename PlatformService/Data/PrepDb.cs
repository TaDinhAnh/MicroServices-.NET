using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void Prepopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void SeedData(AppDBContext context)
        {
            if (!context.PlatForms.Any())
            {
                Console.WriteLine("---> Seeding data ....");
                context.PlatForms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "free" },
                    new Platform() { Name = "Kubernetes", Publisher = "CNCF", Cost = "free" }
                );
            }
            else
            {
                Console.WriteLine("---> We already have data");
            }
        }
    }
}