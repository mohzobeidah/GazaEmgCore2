using GazaEmgCore2.Domain;
using GazaEmgCore2.IRepository;
using GazaEmgCore2.Repository;
using GazaEmgCore2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewComponents
{
    public class AddPersonMovementViewComponent : ViewComponent
    {
        private readonly IMovementRepository _IMovementRepository;
        private readonly HealthCenterRepository _healthCenterRepository;

        public AddPersonMovementViewComponent(IMovementRepository _IMovementRepository, HealthCenterRepository healthCenterRepository )
        {
            _healthCenterRepository = healthCenterRepository;
            this._IMovementRepository = _IMovementRepository;
        }

        public IViewComponentResult Invoke (int? id)
        {


            var personMovement = _IMovementRepository.GetQueryable(x => x.QuarantinedPersonId == id).Include(x => x.HealthCenter).Include(x => x.QuarantinedPerson).ToList();
            var personMovement2 = personMovement.LastOrDefault();
            var movementForCustom = new MovementForCustom
            {
                QuarantinedPerson = personMovement2.QuarantinedPerson,
                OldHealthCenter = personMovement2.HealthCenter,
                HealthCenterList = _healthCenterRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),

            };


            return View("~/Views/Quarantine/_AddPersonMovement.cshtml", movementForCustom);
        }
    }
}
