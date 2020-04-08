using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class HealthCenter
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public User Users { get; set; }

        public DateTime startDate { get; set; }

        public string Address { get; set; }

        public int SecuityCount { get; set; }
        public int MedicsCount { get; set; }
        public int WorkersCount { get; set; }

    }
}
