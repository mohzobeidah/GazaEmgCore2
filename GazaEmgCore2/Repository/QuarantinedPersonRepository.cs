using GazaEmgCore2.Data;
using GazaEmgCore2.Domain;
using GazaEmgCore2.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Repository
{
    public class QuarantinedPersonRepository : Repository<QuarantinedPerson>, IQuarantinedPersonRepository
    {
    
        public QuarantinedPersonRepository(ApplicationContext context):base(context)
        {

        }

      

       public IQueryable<QuarantinedPerson> GetPaginated(string filter, int initalPage, int pageSize, out int totalRecord, out int recordsFilter)
        {


            var data = GetQueryable(x => x.IsDeleted == false);
            totalRecord = GetQueryable(x => x.IsDeleted == false).Count();
            if (!string.IsNullOrEmpty(filter))
            {

                data = data.Where(x => x.IdentityNo.ToString().Contains(filter.ToLower()) ||
                x.Fname.ToLower().Contains(filter.ToLower()) || x.Sname.ToLower().Contains(filter.ToLower())
             || x.Tname.ToLower().Contains(filter.ToLower())  || x.Lname.ToLower().Contains(filter.ToLower())
                );
            }

            recordsFilter = data.Count();
            data = data.OrderByDescending(x => x.InsertDate).Skip(initalPage ).Take(pageSize);
            return data;
        }
    }
}
