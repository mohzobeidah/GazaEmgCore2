using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class MapSetting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool isDeleted { get; set; }
        public string InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
