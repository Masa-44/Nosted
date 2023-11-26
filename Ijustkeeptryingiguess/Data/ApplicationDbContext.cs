// Bruker nødvendige Microsoft-namespace og inkluderer modellene som brukes i konteksten
using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Ijustkeeptryingiguess.Data
{
    // Definerer applikasjonsdatabasens kontekstklasse, som arver fra IdentityDbContext
    public class ApplicationDbContext : IdentityDbContext
    {
        // Konstruktør som tar inn DbContextOptions og sender dem videre til baseklassens konstruktør
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet for SalesLeadEntity-modellen for å kunne utføre operasjoner i databasen
        public DbSet<SalesLeadEntity> SalesLead { get; set; }

        // DbSet for ApplicationUser-modellen (tilpasset brukerklasse) for å kunne utføre operasjoner i databasen
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
