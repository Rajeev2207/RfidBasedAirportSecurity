namespace RfidBasedAirportSecurity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RfidBasedAirportSecurity.Models.RfidBasedAirportSecurityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RfidBasedAirportSecurity.Models.RfidBasedAirportSecurityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.RfidInventories.AddOrUpdate(new Models.RfidInventory[]
            {
                new Models.RfidInventory() { RFID_ID = "read000", Device_Type = "Reader", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "read001", Device_Type = "Reader", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "read002", Device_Type = "Reader", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "read003", Device_Type = "Reader", Status = "Active" },
                new Models.RfidInventory() { RFID_ID = "read004", Device_Type = "Reader", Status = "Active" },
                new Models.RfidInventory() { RFID_ID = "read005", Device_Type = "Reader", Status = "Active" },
                new Models.RfidInventory() { RFID_ID = "pass001", Device_Type = "Tag", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "pass002", Device_Type = "Tag", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "pass003", Device_Type = "Tag", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "lugg001", Device_Type = "Tag", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "lugg002", Device_Type = "Tag", Status = "Active"},
                new Models.RfidInventory() { RFID_ID = "lugg003", Device_Type = "Tag", Status = "Active"},
            });

            context.PassengerAreaAccesses.AddOrUpdate(new Models.PassengerAreaAccess[]
            {
                new Models.PassengerAreaAccess() {ZoneId="D3", RFID_ID="pass001", Access_Time = new DateTime(2019,3,15,1,30,00)},
                new Models.PassengerAreaAccess() {ZoneId="C1", RFID_ID="pass002", Access_Time = new DateTime(2019,3,15,1,30,00)},
                new Models.PassengerAreaAccess() {ZoneId="E1", RFID_ID="pass003", Access_Time = new DateTime(2019,3,15,1,30,00)},
            });

            context.ZoneInfoMetaDatas.AddOrUpdate(new Models.ZoneInfoMetaData[]
            {
                new Models.ZoneInfoMetaData() {ZoneId="B1", RFID_ID="read000", Lat_Long="00/00"},
                new Models.ZoneInfoMetaData() {ZoneId="C1", RFID_ID="read001", Lat_Long="00/00"},
                new Models.ZoneInfoMetaData() {ZoneId="D3", RFID_ID="read002", Lat_Long="00/00"},
                new Models.ZoneInfoMetaData() {ZoneId="E1", RFID_ID="read003", Lat_Long="00/00"},
                new Models.ZoneInfoMetaData() {ZoneId="F1", RFID_ID="read004", Lat_Long="00/00"},
                new Models.ZoneInfoMetaData() {ZoneId="G1", RFID_ID="read005", Lat_Long="00/00"},
            });

            context.FlightDetails.AddOrUpdate(new Models.FlightDetails[]
            {
                new Models.FlightDetails() {Flight_Id="Alaska12", Source="Seattle", Destination="San Jose", Boarding_Gate="C3",
                    Boarding_Time = new DateTime(2019,3,15,11,00,00), Arrival_Time = new DateTime(2019,3,15,11,30,00),
                    Departure_Time = new DateTime(2019,3,15,1,30,00), Status = "", Belt_Id= ""},

                new Models.FlightDetails() {Flight_Id="Delta12", Source="Seattle", Destination="Austin", Boarding_Gate="D2",
                    Boarding_Time = new DateTime(2019,3,18,12,00,00), Arrival_Time = new DateTime(2019,3,18,12,30,00),
                    Departure_Time = new DateTime(2019,3,18,3,30,00), Status = "", Belt_Id= ""},

                new Models.FlightDetails() {Flight_Id="United12", Source="Seattle", Destination="New York", Boarding_Gate="E4",
                    Boarding_Time = new DateTime(2019,3,16,10,00,00), Arrival_Time = new DateTime(2019,3,16,11,30,00),
                    Departure_Time = new DateTime(2019,3,16,1,30,00),Status = "", Belt_Id= ""},

                new Models.FlightDetails() {Flight_Id="Alaska10", Source="San Jose", Destination="Seattle", Boarding_Gate="",
                    Boarding_Time = new DateTime(2019,3,15,9,00,00), Arrival_Time = new DateTime(2019,3,15,11,30,00),
                    Departure_Time = new DateTime(2019,3,15,1,30,00), Status = "Arrived", Belt_Id= "J2"},
            });

            context.PassengerDetails.AddOrUpdate(new Models.PassengerDetails[]
            {
                new Models.PassengerDetails() {PassengerId = "stark1234", Name="Tony Stark", PNR = "PNR000",
                    TimeStamp = new DateTime(2019,3,15,7,00,00), RFID_ID = "pass001", Flight_Id = "Alaska12",
                    Email_id ="tony.stark@gmail.com", Tracking=false, Rfid_Status = "Active", Status_Reason="",
                    IdProofType ="Passport", PassengerType="A"},


                new Models.PassengerDetails() {PassengerId = "banner1234", Name="Bruce Banner", PNR = "PNR001",
                    TimeStamp = new DateTime(2019,3,15,8,00,00), RFID_ID = "pass002", Flight_Id = "United12",
                    Email_id ="bruce.banner@gmail.com", Tracking=true, Rfid_Status = "disabled",
                    Status_Reason ="Suspicious", IdProofType="Driving License", PassengerType="B"},


                new Models.PassengerDetails() {PassengerId = "diana1234", Name="Princess Diana", PNR = "PNR002",
                    TimeStamp = new DateTime(2019,3,16,7,00,00), RFID_ID = "pass003", Flight_Id = "United12",
                    Email_id ="princess.diana@gmail.com", Tracking=false, Rfid_Status = "Active", Status_Reason="",
                    IdProofType ="Passport", PassengerType="A"},
            });

            context.Luggages.AddOrUpdate(new Models.Luggage[]
            {
                new Models.Luggage() { Luggage_RFID_Id="lugg001", Passenger_ID="pass001", Flight_Id="Alaska12",
                    Luggage_Location ="H2", Luggage_Stage="LoadedOnFlight"},
                new Models.Luggage() { Luggage_RFID_Id="lugg002", Passenger_ID="pass001", Flight_Id="Alaska12",
                    Luggage_Location ="H2", Luggage_Stage="LoadedOnFlight"},
                new Models.Luggage() { Luggage_RFID_Id="lugg003", Passenger_ID="pass002", Flight_Id="United12",
                    Luggage_Location ="H1", Luggage_Stage="LoadedOnFlight"},
                new Models.Luggage() { Luggage_RFID_Id="lugg004", Passenger_ID="pass003", Flight_Id="United12",
                    Luggage_Location ="A3", Luggage_Stage="LoadedOnFlight"},
            });
        }
    }
}
