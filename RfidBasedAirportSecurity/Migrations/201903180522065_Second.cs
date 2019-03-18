namespace RfidBasedAirportSecurity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PassengerAreaAccesses", "Role", "dbo.ZoneAccessMetaDatas");
            DropIndex("dbo.PassengerAreaAccesses", new[] { "Role" });
            DropColumn("dbo.PassengerAreaAccesses", "Role");
            DropTable("dbo.ZoneAccessMetaDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZoneAccessMetaDatas",
                c => new
                    {
                        Role = c.String(nullable: false, maxLength: 128),
                        ClassType = c.String(),
                        B1 = c.Boolean(nullable: false),
                        C1 = c.Boolean(nullable: false),
                        D3 = c.Boolean(nullable: false),
                        E1 = c.Boolean(nullable: false),
                        F1 = c.Boolean(nullable: false),
                        G1 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Role);
            
            AddColumn("dbo.PassengerAreaAccesses", "Role", c => c.String(maxLength: 128));
            CreateIndex("dbo.PassengerAreaAccesses", "Role");
            AddForeignKey("dbo.PassengerAreaAccesses", "Role", "dbo.ZoneAccessMetaDatas", "Role");
        }
    }
}
