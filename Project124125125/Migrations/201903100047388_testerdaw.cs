namespace Project124125125.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testerdaw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManagerUsers", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManagerUsers", "Accepted");
        }
    }
}
