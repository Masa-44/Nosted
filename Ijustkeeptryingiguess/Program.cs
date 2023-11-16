using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Ijustkeeptryingiguess.Models;
using MySqlConnector;
using System.Data;
using Ijustkeeptryingiguess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
                        services.AddRazorPages();

                        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<ApplicationDbContext>();

                        // Configure the database connection.
                        var configuration = hostContext.Configuration;
                        var connectionString = configuration.GetConnectionString("DefaultConnection");
                       

                        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 3, 0))));
                   


                        services.AddScoped<IDbConnection>(_=> new MySqlConnection(connectionString));

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
                        appBuilder.UseAuthentication();
                        appBuilder.UseAuthorization();

                        appBuilder.MapRazorPages();

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