using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class Capital
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string GenCountry { get; set; }

        public string Continent { get; set; }

        public string Continent_part { get; set; } // так названо в справочнике. Лень разделять сущность на две

        public bool DuplicateName { get; set; }

        public List<string> Facts { get; set; }

        public int Complexity { get; set; }
    }
}
