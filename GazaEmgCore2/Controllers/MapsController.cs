using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GazaEmgCore2.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GazaEmgCore2.Controllers
{
    public class MapsController : Controller
    {
        private IMapSettingRepository _IMapSettingRepository;

        public MapsController(IMapSettingRepository mapSettingRepository)
        {
            _IMapSettingRepository = mapSettingRepository;
        }
        public IActionResult Index()
        {
            var map =_IMapSettingRepository.GetQueryable(x => x.Id == 4).FirstOrDefault();
            
            return View(map);
        }
    }
}