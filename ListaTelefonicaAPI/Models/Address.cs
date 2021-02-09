using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonicaAPI.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; } 
        public string Marker { get; set; }
        public int ContactId { get; set; }
    }
}
