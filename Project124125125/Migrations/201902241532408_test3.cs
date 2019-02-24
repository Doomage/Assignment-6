namespace Project124125125.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Roles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Roles", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Role");
        }
    }
}
