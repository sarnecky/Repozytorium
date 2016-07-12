namespace zabawa_z_gitem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TextFiles",
                c => new
                    {
                        TextFileId = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        Name = c.String(),
                        AddedDateTime = c.DateTime(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TextFileId)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextFiles", "TypeId", "dbo.Types");
            DropIndex("dbo.TextFiles", new[] { "TypeId" });
            DropTable("dbo.Types");
            DropTable("dbo.TextFiles");
        }
    }
}
