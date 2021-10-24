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
    }
}
