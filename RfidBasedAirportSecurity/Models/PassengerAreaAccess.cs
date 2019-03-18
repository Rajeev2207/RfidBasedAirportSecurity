using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RfidBasedAirportSecurity.Models
{
    public class PassengerAreaAccess
    {
        [Key]
        public string ZoneId { get; set; }  // Primary Key

        [ForeignKey("RfidInventory")]
        public string RFID_ID { get; set; }
        public RfidInventory RfidInventory { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]  // similar to SYSDATE
        public DateTime Access_Time { get; set; }

    }
}