using Shared.Models.Db;
using Shared.Models.NodeTypes;
using System.Data.Entity;

namespace EfUniversityHierarchical
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
            : base("DbConnection")
        { }

        public DbSet<UniversityItem> UniversityItems { get; set; }

        public DbSet<NodeType> NodeTypes { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UniversityContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
