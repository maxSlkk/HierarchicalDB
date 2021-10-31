namespace EfUniversityHierarchical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UniversityItems");

            DropColumn("dbo.UniversityItems", "Id");
            AddColumn("dbo.UniversityItems", "Id", c => c.Guid(nullable: false));

            DropColumn("dbo.UniversityItems", "ParentId");
            AddColumn("dbo.UniversityItems", "ParentId", c => c.Guid());

            AddPrimaryKey("dbo.UniversityItems", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UniversityItems");

            DropColumn("dbo.UniversityItems", "Id");
            AddColumn("dbo.UniversityItems", "Id", c => c.Int(nullable: false, identity: true));

            DropColumn("dbo.UniversityItems", "ParentId");
            AddColumn("dbo.UniversityItems", "ParentId", c => c.Int());

            AddPrimaryKey("dbo.UniversityItems", "Id");
        }
    }
}
