namespace EfUniversityHierarchical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNodeTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NodeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UniversityItems", "NodeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.UniversityItems", "NodeTypeId");
            AddForeignKey("dbo.UniversityItems", "NodeTypeId", "dbo.NodeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UniversityItems", "NodeTypeId", "dbo.NodeTypes");
            DropIndex("dbo.UniversityItems", new[] { "NodeTypeId" });
            DropColumn("dbo.UniversityItems", "NodeTypeId");
            DropTable("dbo.NodeTypes");
        }
    }
}
