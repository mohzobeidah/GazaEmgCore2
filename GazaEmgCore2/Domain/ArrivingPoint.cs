using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class ArrivingPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ArrivingPointDetail> ArrivingPointDetails { get; set; }

    }
}
