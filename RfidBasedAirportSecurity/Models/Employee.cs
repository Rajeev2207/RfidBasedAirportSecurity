using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RfidBasedAirportSecurity.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        //[ForeignKey("RfidInventory")]
        public string RFID_ID { get; set; }
        public RfidInventory RfidInventory { get; set; }

        public int ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmployeeType { get; set; }
    }
}