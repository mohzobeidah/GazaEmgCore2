using GazaEmgCore2.Data;
using GazaEmgCore2.Domain;
using GazaEmgCore2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.IRepository
{
    public class ArrivingPointDetailRepository : Repository<ArrivingPointDetail>, IArrivingPointDetailRepository
    {

        
    public ArrivingPointDetailRepository(ApplicationContext context) : base(context)
    {

    }
    
    }
}
