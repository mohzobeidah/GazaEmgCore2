using GazaEmgCore2.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewComponents
{
    public class GetPersonDetailViewComponent: ViewComponent
    {
        private readonly IQuarantinedPersonRepository _IQuarantinedPersonRepository;

        public GetPersonDetailViewComponent(IQuarantinedPersonRepository IQuarantinedPersonRepository)
        {
            this._IQuarantinedPersonRepository = IQuarantinedPersonRepository;
        }

        public IViewComponentResult Invoke(int? Id)
        {
            var person =  _IQuarantinedPersonRepository.GetQueryable(x => x.Id == Id).
                Include(x => x.ArrivingPoint).Include(x => x.ArrivingPointDetails).
                Include(x => x.Governorates).Include(x => x.Cities).ToList();
                //.Include(x => x.nationality).Include(x => x.IDType).Include(x => x.gender).ToList();
            var PersonOne = person.FirstOrDefault();
            return View("~/Views/Quarantine/_GetPersonDetails.cshtml", PersonOne);
        }
    }
}
