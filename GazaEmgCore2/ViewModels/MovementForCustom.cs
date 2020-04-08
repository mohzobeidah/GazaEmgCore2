using GazaEmgCore2.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewModels
{
    public class MovementForCustom
    {

        public int Id { get; set; }
        public int QuarantinedPersonId { get; set; }

      
        public QuarantinedPerson QuarantinedPerson { get; set; }


        public int OldHealthCenterId { get; set; }
        public HealthCenter OldHealthCenter { get; set; }

        public HealthCenter HealthCenter { get; set; }
        public int HealthCenterId { get; set; }

        public string Reason { get; set; }
        public string HealthStatus { get; set; }
        public string Order { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdatetUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsDeleted { get; set; }

        public List<SelectListItem> HealthCenterList { get; set; }
    }
}
