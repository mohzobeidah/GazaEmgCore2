using GazaEmgCore2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.IRepository
{
    public interface IQuarantinedPersonRepository :IRepository<QuarantinedPerson>
    {

        IQueryable<QuarantinedPerson> GetPaginated(string filter, int initalPage, int pageSize, out int totalRecord, out int recordsFilter);
     
    }
}
