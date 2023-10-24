using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Ijustkeeptryingiguess.Models;
using MySqlConnector;
using System.Data;

namespace Ijustkeeptryingiguess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Add services to the container.
                        services.AddControllersWithViews();

                        // Configure the database connection.
                        var configuration = hostContext.Configuration;
                        var connectionString = configuration.GetConnectionString("DefaultConnection");
                        services.AddScoped<IDbConnection>(_ => new MySqlConnection(connectionString));

                        // Register your repository here.
                        services.AddTransient<ServiceOrdreRepository>();
                    });

                    webBuilder.Configure((appBuilder) =>
                    {
                        var env = appBuilder.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            appBuilder.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            appBuilder.UseExceptionHandler("/Home/Error");
                            appBuilder.UseHsts();
                        }

                        appBuilder.UseHttpsRedirection();
                        appBuilder.UseStaticFiles();
                        appBuilder.UseRouting();
                        appBuilder.UseAuthorization();

                        /*appBuilder.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });*/

                        appBuilder.UseEndpoints(endpoints =>
                        {
                            // Custom Route
                            endpoints.MapControllerRoute(
                            name: "customRoute",
                            pattern: "custom/nyserviceordre", // Adjust the route pattern to your needs
                            defaults: new { controller = "Home", action = "NyServiceOrdre" });

                            // Default Route
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
                    });
                });
    }
}