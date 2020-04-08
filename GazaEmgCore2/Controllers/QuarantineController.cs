using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using GazaEmgCore2.Common;
using GazaEmgCore2.Domain;
using GazaEmgCore2.Enum;
using GazaEmgCore2.IRepository;
using GazaEmgCore2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GazaEmgCore2.Controllers
{
    public class QuarantineController : Controller
    {
       
        private readonly IQuarantinedPersonRepository _IQuarantinedPersonRepository;
        private readonly IMapper _mapper;
        private readonly IMovementRepository _IMovementRepository;  
        public readonly IArrivingPointDetailRepository _arrivingPointDetailRepository ; 

        private readonly IArrivingPointRepository _arrivingPointRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IHealthCenterRepository _healthCenterRepository;
        private readonly IGovernorateRepository _governorateRepository;

        public QuarantineController(IQuarantinedPersonRepository IQuarantinedPersonRepository, 
            IMapper mapper, IArrivingPointDetailRepository  arrivingPointDetailRepository,
            IArrivingPointRepository arrivingPointRepository, IGovernorateRepository governorateRepository
            , ICityRepository cityRepository, IHealthCenterRepository healthCenterRepository,
            IMovementRepository _IMovementRepository

            )
        {
            this._IQuarantinedPersonRepository = IQuarantinedPersonRepository;
            _mapper = mapper;
            _arrivingPointDetailRepository = arrivingPointDetailRepository;
            _arrivingPointRepository = arrivingPointRepository;
            _governorateRepository = governorateRepository;
            _cityRepository = cityRepository;
            _healthCenterRepository = healthCenterRepository;
            this._IMovementRepository = _IMovementRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public   IActionResult GetPersonsAjax(DataTablesParam param)
        {
            int totalNo = 0, recordFilter = 0;
            var QuauntiedPesonList = _IQuarantinedPersonRepository.GetPaginated(param.sSearch, param.iDisplayStart, param.iDisplayLength, out totalNo, out recordFilter);
            return Json(new 
            {
                data = QuauntiedPesonList,
                eEcho = param.sEcho,
                iTotalDisplayRecords = recordFilter,
                iTotalRecords = totalNo
            }); 
        }

        public IActionResult AddPerson()
        {


            var quarantinedPersonVM = new QuarantinedPersonVM
            {
                Nationalitieslist = NationalityModel.ConvertEnumToList<Nationality>().ToList(),
                IdTypeEnumList = IdTypeEnumModel.ConvertEnumToList<IdTypeEnum>().ToList(),
                GenderEnumList = GenderEnumModel.ConvertEnumToList<GenderEnum>().ToList(),
                ArrivingPointList = _arrivingPointRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                HealthCenterList = _healthCenterRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                GovernateList = _governorateRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList()
            };

            
            return View(quarantinedPersonVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson(QuarantinedPersonVM model)
        {

            if (ModelState.IsValid)
            {

                if (model.IdentityNo!= null && model.IDType==1 && model.IdentityNo.ToString().Trim().Length !=9 )
                {
                    return Json(new
                    {
                        status = JsonStatus.Error,
                        link = "تنبيه",
                        color = NotificationColor.error.ToString().ToLower(),
                        msg = "رقم الهوية  لابد ان يكون رقم صحيح "
                    });
                }
                if (model.IdentityNo != null && model.IDType == 1 &&  !Regex.IsMatch(model.IdentityNo.ToString(), @"^[0-9]*$"))
                {
                    return Json(new
                    {
                        status = JsonStatus.Error,
                        link = "تنبيه",
                        color = NotificationColor.error.ToString().ToLower(),
                        msg = "رقم الهوية  لابد ان يكون رقم صحيح "
                    });
                }
                var checkIdentity = await _IQuarantinedPersonRepository.GetAsync(x => x.IdentityNo == model.IdentityNo);

                if (checkIdentity.Count() != 0) {
                    return Json(new
                    {
                        status = JsonStatus.Error,
                        link = "تنبيه",
                        color = NotificationColor.error.ToString().ToLower(),
                        msg = "رقم الهوية او جواز السفر  موجود مسبقا ارجو التاكد من كشف النزلاء"
                    });
                } 

                
                model.ArrivalDate = model.ArrivalDate.Value.Add(model.ArrivalTime.Value);
                model.InsertDate =DateTime.UtcNow;
                model.InsertUser = "Testuser";

               
                var ModelForDB = _mapper.Map<QuarantinedPerson>(model);
               var result =await _IQuarantinedPersonRepository.AddAndLogAsync(ModelForDB,"Testuser");
                 
                if (result >0) { 
                var MovementToDB = new Movement 
                {
                    QuarantinedPersonId = ModelForDB.Id,
                    HealthCenterId=model.HealthCenter.Value,
                    HealthStatus=  model.HealthStatus,
                    Reason= "تسجيل لاول مرة ",
                    InsertUser = "Testuser",
                    InsertDate = DateTime.UtcNow,
                };
                    var result2 =await _IMovementRepository.AddAndLogAsync(MovementToDB, "Testuser");
                    if (result > 0 && result2>0)
                    {
                        return Json(new
                        {
                            status = JsonStatus.Success,
                            link = "جيد",
                            color = NotificationColor.success.ToString().ToLower(),
                            msg = "تم الحفظ نجاح"
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            status = JsonStatus.Error,
                            link = "يوجد خطا",
                            color = NotificationColor.error.ToString().ToLower(),
                            msg = "يوجد خطا في عملية الحفظ"
                        });

                    }
                }
              
                else
                {
                    return Json(new
                    {
                        status = JsonStatus.Error,
                        link = "يوجد خطا",
                        color = NotificationColor.error.ToString().ToLower(),
                        msg = "يوجد خطا في عملية الحفظ"
                    });

                }

            }

            

            //model = new QuarantinedPersonVM
            //{
            //    Nationalitieslist = NationalityModel.ConvertEnumToList<Nationality>().ToList(),
            //    IdTypeEnumList = IdTypeEnumModel.ConvertEnumToList<IdTypeEnum>().ToList(),
            //    GenderEnumList = GenderEnumModel.ConvertEnumToList<GenderEnum>().ToList(),
            //    ArrivingPointList =   _arrivingPointRepository.GetAllQuerable().Select(x=> new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),
            //    HealthCenterList = _healthCenterRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),
            //    GovernateList = _governorateRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList()

            //};


            return Json(new
            {
                status = JsonStatus.Error,
                link = "",
                color = NotificationColor.error.ToString().ToLower(),
                msg = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray()
            });
        }

        public async Task<IActionResult> GetArrivingPointDetail(int ?Id)
        {
             if(Id == null)
                return Json(null);

            var ListDetalis = _arrivingPointDetailRepository.GetQueryable(x => x.ArrivingPoints.Id == Id);
            return Json(ListDetalis.ToList());
         }

        public async Task<IActionResult> GetCities(int? Id)
        {
            if (Id == null)
                return Json(null);

            var ListCitiies = _cityRepository.GetQueryable(x => x.Governorate.Id == Id);
            return Json(ListCitiies.ToList());
        }

        public async Task<IActionResult> checKIdentity(string id)
        {

            var checkIdentity = await _IQuarantinedPersonRepository.GetAsync(x => x.IdentityNo == id);

            if (checkIdentity != null)
                return Json(1);
            else
                return Json(0);
        }

        public IActionResult GetMovement()
        {

            return PartialView();
        }

        public async Task<IActionResult> Details(int ? id)
        {
            if (id == null)
                return BadRequest();
            var checkIdExist = _IQuarantinedPersonRepository.Get(x => x.Id == id).FirstOrDefault();
             if (checkIdExist== null)
                return BadRequest();

            return View(checkIdExist);
        }


        public async Task<IActionResult> AddPersonMovement(int? id)
        {
            if (id == null)
                return BadRequest();

           var personMovement= _IMovementRepository.GetQueryable(x => x.QuarantinedPersonId == id).Include(x => x.HealthCenter).Include(x => x.QuarantinedPerson).ToList();
            var personMovement2 = personMovement.LastOrDefault();
            var movementForCustom = new MovementForCustom
            {
                QuarantinedPerson = personMovement2.QuarantinedPerson,
                OldHealthCenter = personMovement2.HealthCenter,
                OldHealthCenterId = personMovement2.HealthCenter.Id,
                HealthCenterList = _healthCenterRepository.GetAllQuerable().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),

            };


            return PartialView ("~/Views/Quarantine/_AddPersonMovement.cshtml", movementForCustom);

          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPersonMovement(MovementForCustom model )
        {
            if (ModelState.IsValid)
            {
                //var personMovement = _IMovementRepository.GetQueryable(x => x.QuarantinedPersonId == id).Include(x => x.HealthCenter).Include(x => x.QuarantinedPerson).ToList();
                //var personMovement2 = personMovement.LastOrDefault();
                
                if (model.OldHealthCenterId == model.HealthCenterId)
                {

                    return Json(new
                    {
                        status = JsonStatus.Exist,
                        link = "تنبيه",
                        color = NotificationColor.warning.ToString().ToLower(),
                        msg = "هذا  النزيل موجود في نفس المكرز الصحي "
                    });
                }


                var movement = new Movement
                {
                    QuarantinedPersonId = model.QuarantinedPerson.Id,
                    HealthCenterId = model.HealthCenterId,
                    Reason = model.Reason,
                    HealthStatus=model.HealthStatus,
                    Order=model.Order,
                    InsertDate= DateTime.UtcNow,
                   InsertUser = "Testuser",

                };
                var result = await _IMovementRepository.AddAndLogAsync(movement, "Testuser");

                if (result > 0)
                {
                    return Json(new
                    {
                        status = JsonStatus.Success,
                        link = "جيد",
                        color = NotificationColor.success.ToString().ToLower(),
                        msg = "تم الحفظ نجاح"
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = JsonStatus.Error,
                        link = "يوجد خطا",
                        color = NotificationColor.error.ToString().ToLower(),
                        msg = "يوجد خطا في عملية الحفظ"
                    });

                }
            }



            return Json(new
            {
                status = JsonStatus.Error,
                link = "",
                color = NotificationColor.error.ToString().ToLower(),
                msg = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray()
            });


        }
    }
}