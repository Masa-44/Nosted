using Ijustkeeptryingiguess.Models;
using Microsoft.EntityFrameworkCore;

namespace Ijustkeeptryingiguess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SalesLeadEntity> SalesLead { get; set;}
    }
}
