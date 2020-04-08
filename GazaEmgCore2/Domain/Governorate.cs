using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class Governorate
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
