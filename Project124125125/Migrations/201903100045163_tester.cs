namespace Project124125125.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tester : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Accepted");
        }
    }
}
