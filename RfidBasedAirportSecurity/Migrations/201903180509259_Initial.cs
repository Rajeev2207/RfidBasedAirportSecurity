namespace RfidBasedAirportSecurity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightDetails",
                c => new
                    {
                        Flight_Id = c.String(nullable: false, maxLength: 128),
                        Source = c.String(nullable: false),
                        Destination = c.String(nullable: false),
                        Boarding_Gate = c.String(),
                        Boarding_Time = c.DateTime(nullable: false),
                        Arrival_Time = c.DateTime(nullable: false),
                        Departure_Time = c.DateTime(nullable: false),
                        Status = c.String(),
                        Belt_Id = c.String(),
                    })
                .PrimaryKey(t => t.Flight_Id);
            
            CreateTable(
                "dbo.Luggages",
                c => new
                    {
                        Luggage_RFID_Id = c.String(nullable: false, maxLength: 128),
                        Passenger_ID = c.String(),
                        Flight_Id = c.String(maxLength: 128),
                        Luggage_Stage = c.String(),
                        Luggage_Location = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        PassengerDetails_PassengerId = c.String(maxLength: 128),
                        PassengerDetails_PNR = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Luggage_RFID_Id)
                .ForeignKey("dbo.FlightDetails", t => t.Flight_Id)
                .ForeignKey("dbo.PassengerDetails", t => new { t.PassengerDetails_PassengerId, t.PassengerDetails_PNR })
                .Index(t => t.Flight_Id)
                .Index(t => new { t.PassengerDetails_PassengerId, t.PassengerDetails_PNR });
            
            CreateTable(
                "dbo.PassengerDetails",
                c => new
                    {
                        PassengerId = c.String(nullable: false, maxLength: 128),
                        PNR = c.String(nullable: false, maxLength: 128),
                        IdProofType = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        RFID_ID = c.String(maxLength: 128),
                        Flight_Id = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                        Email_id = c.String(),
                        Tracking = c.Boolean(nullable: false),
                        Rfid_Status = c.String(),
                        Status_Reason = c.String(),
                        PassengerType = c.String(),
                    })
                .PrimaryKey(t => new { t.PassengerId, t.PNR })
                .ForeignKey("dbo.FlightDetails", t => t.Flight_Id)
                .ForeignKey("dbo.RfidInventories", t => t.RFID_ID)
                .Index(t => t.RFID_ID)
                .Index(t => t.Flight_Id);
            
            CreateTable(
                "dbo.RfidInventories",
                c => new
                    {
                        RFID_ID = c.String(nullable: false, maxLength: 128),
                        Device_Type = c.String(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RFID_ID);
            
            CreateTable(
                "dbo.PassengerAreaAccesses",
                c => new
                    {
                        ZoneId = c.String(nullable: false, maxLength: 128),
                        RFID_ID = c.String(maxLength: 128),
                        Access_Time = c.DateTime(nullable: false),
                        Role = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ZoneId)
                .ForeignKey("dbo.RfidInventories", t => t.RFID_ID)
                .ForeignKey("dbo.ZoneAccessMetaDatas", t => t.Role)
                .Index(t => t.RFID_ID)
                .Index(t => t.Role);
            
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
            
            CreateTable(
                "dbo.ZoneInfoMetaDatas",
                c => new
                    {
                        ZoneId = c.String(nullable: false, maxLength: 128),
                        RFID_ID = c.String(maxLength: 128),
                        Lat_Long = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ZoneId)
                .ForeignKey("dbo.RfidInventories", t => t.RFID_ID)
                .Index(t => t.RFID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneInfoMetaDatas", "RFID_ID", "dbo.RfidInventories");
            DropForeignKey("dbo.PassengerAreaAccesses", "Role", "dbo.ZoneAccessMetaDatas");
            DropForeignKey("dbo.PassengerAreaAccesses", "RFID_ID", "dbo.RfidInventories");
            DropForeignKey("dbo.Luggages", new[] { "PassengerDetails_PassengerId", "PassengerDetails_PNR" }, "dbo.PassengerDetails");
            DropForeignKey("dbo.PassengerDetails", "RFID_ID", "dbo.RfidInventories");
            DropForeignKey("dbo.PassengerDetails", "Flight_Id", "dbo.FlightDetails");
            DropForeignKey("dbo.Luggages", "Flight_Id", "dbo.FlightDetails");
            DropIndex("dbo.ZoneInfoMetaDatas", new[] { "RFID_ID" });
            DropIndex("dbo.PassengerAreaAccesses", new[] { "Role" });
            DropIndex("dbo.PassengerAreaAccesses", new[] { "RFID_ID" });
            DropIndex("dbo.PassengerDetails", new[] { "Flight_Id" });
            DropIndex("dbo.PassengerDetails", new[] { "RFID_ID" });
            DropIndex("dbo.Luggages", new[] { "PassengerDetails_PassengerId", "PassengerDetails_PNR" });
            DropIndex("dbo.Luggages", new[] { "Flight_Id" });
            DropTable("dbo.ZoneInfoMetaDatas");
            DropTable("dbo.ZoneAccessMetaDatas");
            DropTable("dbo.PassengerAreaAccesses");
            DropTable("dbo.RfidInventories");
            DropTable("dbo.PassengerDetails");
            DropTable("dbo.Luggages");
            DropTable("dbo.FlightDetails");
        }
    }
}
