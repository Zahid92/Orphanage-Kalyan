using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orphanage_Kalyan.Models
{
    public class Orphanage
    {
        public string Name { get; set; }
        public int RegistrationId { get; set; }
        public string Email { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        
    }
}