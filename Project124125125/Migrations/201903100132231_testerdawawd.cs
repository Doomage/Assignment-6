namespace Project124125125.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testerdawawd : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ManagerUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ManagerUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
