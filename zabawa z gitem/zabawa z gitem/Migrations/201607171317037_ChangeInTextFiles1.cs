namespace zabawa_z_gitem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInTextFiles1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextFiles", "UserName", c => c.String());
            DropColumn("dbo.TextFiles", "AspNetUsersName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TextFiles", "AspNetUsersName", c => c.String());
            DropColumn("dbo.TextFiles", "UserName");
        }
    }
}
