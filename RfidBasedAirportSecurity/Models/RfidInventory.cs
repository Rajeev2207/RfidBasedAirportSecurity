using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RfidBasedAirportSecurity.Models
{
    public class RfidInventory
    {
        [Key]
        public string RFID_ID { get; set; }

        [Required]
        public string Device_Type { get; set; }  // Store Values as Tag/Reader.

        public string Status { get; set; }  // Stores Issued(Tags)/OutOfService/Working.
    }
}