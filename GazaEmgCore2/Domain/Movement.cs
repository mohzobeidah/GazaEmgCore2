using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class Movement
    {

        public int Id { get; set; }
        public int QuarantinedPersonId { get; set; }

        [ForeignKey(nameof(QuarantinedPersonId))]
        public QuarantinedPerson QuarantinedPerson { get; set; }


        public int HealthCenterId { get; set; }

        [ForeignKey(nameof(HealthCenterId))]
        public HealthCenter HealthCenter { get; set; }

        public string Reason { get; set; }
        public string HealthStatus { get; set; }
        public string Order { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdatetUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
