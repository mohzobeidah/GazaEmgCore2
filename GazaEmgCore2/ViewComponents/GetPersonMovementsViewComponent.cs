using GazaEmgCore2.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewComponents
{

    public class GetPersonMovementsViewComponent: ViewComponent
    {
        private readonly IMovementRepository _IMovementRepository;

        public GetPersonMovementsViewComponent(IMovementRepository _IMovementRepository)
        {

            this._IMovementRepository = _IMovementRepository;
        }

        public IViewComponentResult Invoke(int? Id)
        {
            var personMovement = _IMovementRepository.GetQueryable(x => x.QuarantinedPersonId == Id).Include(x => x.HealthCenter).ToList();
                
       
            return View("~/Views/Quarantine/_GetPersonMovements.cshtml", personMovement);
        }
    }
}
