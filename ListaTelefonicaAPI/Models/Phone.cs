using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaTelefonicaAPI.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public virtual CountryCode CountryCode { get; set; }
        public int CountryCodeId { get; set; }
        public int ContactId { get; set; }
        public string Number { get; set; }
        public string Marker { get; set; }
    }
}
