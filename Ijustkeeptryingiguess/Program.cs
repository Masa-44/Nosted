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
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Http;

namespace Ijustkeeptryingiguess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Starter webapplikasjonen
            CreateHostBuilder(args).Build().Run();
        }

        // Konfigurerer webverten
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Legger til nødvendige tjenester i kontaineren

                        // Legger til kontroller- og Razor Pages-tjenester
                        services.AddControllersWithViews();
                        services.AddRazorPages();

                        // Legger til Identity-tjenester med MySQL som databackend
                        services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
                        .AddRoles<IdentityRole>() // Legger til roller i Identity
                        .AddEntityFrameworkStores<ApplicationDbContext>(); // Konfigurerer Entity Framework med ApplicationDbContext

                        // Konfigurerer databaseforbindelsen
                        var configuration = hostContext.Configuration;
                        var connectionString = configuration.GetConnectionString("DefaultConnection");

                        // Legger til DbContext med MySQL
                        services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 3, 0))));

                        // Legger til en enkeltstående databaseforbindelse for Dependency Injection
                        services.AddScoped<IDbConnection>(_ => new MySqlConnection(connectionString));

                        // Registrerer repositoryet
                        services.AddTransient<ServiceOrdreRepository>();
                    });

                    webBuilder.Configure((appBuilder) =>
                    {
                        var env = appBuilder.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                        // Konfigurerer middleware-avhengig av miljø

                        if (env.IsDevelopment())
                        {
                            appBuilder.UseDeveloperExceptionPage(); // Bruk feilside i utviklingsmiljø
                        }
                        else
                        {
                            appBuilder.UseExceptionHandler("/Home/Error"); // Bruk feilside i produksjonsmiljø
                            appBuilder.UseHsts();
                        }

                        appBuilder.UseHttpsRedirection();
                        appBuilder.UseStaticFiles();
                        appBuilder.UseRouting();
                        appBuilder.UseAuthentication();
                        appBuilder.UseAuthorization();

                        // Konfigurerer sluttpunkter og ruter

                        appBuilder.UseEndpoints(endpoints =>
                        {
                            // Tilpasset rute for en spesifikk handling
                            endpoints.MapControllerRoute(
                                name: "customRoute",
                                pattern: "custom/nyserviceordre", // Juster rute-mønsteret etter behov
                                defaults: new { controller = "Home", action = "NyServiceOrdre" });

                            // Standard Razor Pages-rute
                            endpoints.MapRazorPages();

                            // Standard kontroller-rute
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
                    });
                });
        }
    }
}
