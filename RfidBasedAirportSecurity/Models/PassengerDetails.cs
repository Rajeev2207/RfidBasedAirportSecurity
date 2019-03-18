using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RfidBasedAirportSecurity.Models
{
    public class PassengerDetails
    {
        [Key]
        [Column(Order = 1)]
        public string PassengerId { get; set; } // Primary Key

        public string IdProofType { get; set; }

        [Key]
        [Column(Order = 2)]
        public string PNR { get; set; } // Primary Key

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]  // similar to SYSDATE
        public DateTime TimeStamp { get; set; }

        [ForeignKey("RfidInventory")]
        public string RFID_ID { get; set; }
        public RfidInventory RfidInventory { get; set; }

        [ForeignKey("FlightDetails")]
        public string Flight_Id { get; set; }
        public FlightDetails FlightDetails { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email_id { get; set; }
        public bool Tracking { get; set; }
        public string Rfid_Status { get; set; }
        public string Status_Reason { get; set; }
        public string PassengerType { get; set; }
    }
}