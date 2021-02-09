using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ListaTelefonicaWeb
{
    public class Contato
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public IEnumerable<Phone> phones { get; set; }
        public IEnumerable<Address> addresses { get; set; }
    }
}
