using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class ArrivingPointDetail
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ArrivingPoint ArrivingPoints { get; set; }
    }
}
