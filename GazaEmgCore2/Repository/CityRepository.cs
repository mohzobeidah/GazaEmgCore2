using GazaEmgCore2.Data;
using GazaEmgCore2.Domain;
using GazaEmgCore2.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Repository
{
    public class CityRepository: Repository<City>, ICityRepository
    {

       
        public CityRepository(ApplicationContext context) : base(context)
    {

    }
    
    }
}
