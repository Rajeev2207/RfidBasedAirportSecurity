using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RfidBasedAirportSecurity.Models
{
    public class RfidBasedAirportSecurityContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RfidBasedAirportSecurityContext() : base("name=RfidBasedAirportSecurityContext")
        {
        }

        public System.Data.Entity.DbSet<RfidBasedAirportSecurity.Models.RfidInventory> RfidInventories { get; set; }

        public System.Data.Entity.DbSet<RfidBasedAirportSecurity.Models.ZoneInfoMetaData> ZoneInfoMetaDatas { get; set; }

        public System.Data.Entity.DbSet<RfidBasedAirportSecurity.Models.FlightDetails> FlightDetails { get; set; }

        public System.Data.Entity.DbSet<RfidBasedAirportSecurity.Models.PassengerDetails> PassengerDetails { get; set; }

        public System.Data.Entity.DbSet<RfidBasedAirportSecurity.Models.PassengerAreaAccess> PassengerAreaAccesses { get; set; }

        public System.Data.Entity.DbSet<RfidBasedAirportSecurity.Models.Luggage> Luggages { get; set; }
    }
}
