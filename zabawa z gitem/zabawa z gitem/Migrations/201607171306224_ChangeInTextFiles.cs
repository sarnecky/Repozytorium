namespace zabawa_z_gitem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInTextFiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextFiles", "AspNetUsersName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextFiles", "AspNetUsersName");
        }
    }
}
