using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web.Data
{
    public class FitnessDBContext : IdentityDbContext
    {
        public FitnessDBContext(DbContextOptions<FitnessDBContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            //to be continued when configs are written
        }
    }
}
