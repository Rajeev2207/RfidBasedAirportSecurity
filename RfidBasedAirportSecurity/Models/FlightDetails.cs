using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RfidBasedAirportSecurity.Models
{
    public class FlightDetails
    {
        [Key]
        public string Flight_Id { get; set; } // Primary Key

        [Required]
        public string Source { get; set; } // Not Null
        [Required]
        public string Destination { get; set; } // Not Null

        public string Boarding_Gate { get; set; }
        public DateTime Boarding_Time { get; set; }
        public DateTime Arrival_Time { get; set; }
        public DateTime Departure_Time { get; set; }
        public string Status { get; set; }
        public string Belt_Id { get; set; }
    }
}