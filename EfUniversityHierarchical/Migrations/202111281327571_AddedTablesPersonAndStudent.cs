namespace EfUniversityHierarchical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTablesPersonAndStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        UniversityItemId = c.Guid(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UniversityItemId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        UniversityItemId = c.Guid(nullable: false),
                        GradebookNumber = c.String(),
                    })
                .PrimaryKey(t => t.UniversityItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.People");
        }
    }
}
