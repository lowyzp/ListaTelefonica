using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonicaWeb
{
    public class Phone
    {
        public int id { get; set; }
        public virtual CountryCode countryCode { get; set; }
        public int countryCodeId { get; set; }
        public int contactId { get; set; }
        public string number { get; set; }
        public string marker { get; set; }
    }
}
