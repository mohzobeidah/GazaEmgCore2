using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }

        public string ID_No { get; set; }

        public int HealthCenterId { get; set; }

        [ForeignKey(nameof(HealthCenterId))]
        public HealthCenter HealthCenters { get; set; }
    }
}
