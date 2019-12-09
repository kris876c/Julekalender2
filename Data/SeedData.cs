using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Julekalender.Models;

namespace Julekalender.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JulekalenderContext(serviceProvider.GetRequiredService<DbContextOptions<JulekalenderContext>>()))
            {
                if (context.Factoids.Any())
                {
                    return;
                }

                context.Factoids.AddRange(
                    new Factoids
                    {
                        Fact = "Entity framework skal anvende scoped lifetime"
                    });

                context.Factoids.AddRange(
                    new Factoids
                    {
                        Fact = "Content type er json, xml, og andre "
                    });

                context.Factoids.AddRange(
                    new Factoids
                    {
                        Fact = "Razor View bruger MVVM"
                    });

                context.Factoids.AddRange(
                    new Factoids
                    {
                        Fact = "Controllers bruger MVC"
                    });

                context.Factoids.AddRange(
                    new Factoids
                    {
                        Fact = "Swagger kan give et nemt overblik over ens API'er"
                    });

                for (int i = 6; i < 25; i++)
                {
                    context.Factoids.AddRange(
                    new Factoids
                    {
                        Fact = "Tip " + i
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
