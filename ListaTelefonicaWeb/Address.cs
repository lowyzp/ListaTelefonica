using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonicaWeb
{
    public class Address
    {
        public int id { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string marker { get; set; }
        public int contactid { get; set; }
    }
}
