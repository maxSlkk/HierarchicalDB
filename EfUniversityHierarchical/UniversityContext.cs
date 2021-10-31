using Shared.Models;
using System.Data.Entity;

namespace EfUniversityHierarchical
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
            : base("DbConnection")
        { }

        public DbSet<UniversityItem> UniversityItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UniversityContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
