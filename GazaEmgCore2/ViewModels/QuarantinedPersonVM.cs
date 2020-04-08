using GazaEmgCore2.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewModels
{
    public class QuarantinedPersonVM
    {

        public int Id { get; set; }
        [Required(ErrorMessage =" الحقل  الهوية مطلوب")]
        public string IdentityNo { get; set; }
        [Required(ErrorMessage = " الحقل نوع الوثيقة  مطلوب")]
        public int IDType { get; set; }
        [Required(ErrorMessage = " الحقل الجنسية  مطلوب")]
        public int nationality { get; set; }
        [Required(ErrorMessage = " الحقل  المركز الصحي مطلوب")]
        public int? HealthCenter { get; set; }

        [Required(ErrorMessage = " الحقل الاسم الاول مطلوب")]
        public string Fname { get; set; }
        [Required(ErrorMessage = " الحقل  اسم الاب مطلوب")]
        public string Sname { get; set; }
        [Required(ErrorMessage = " الحقل اسم الجد  مطلوب")]
        public string Tname { get; set; }
        [Required(ErrorMessage = " الحقل  اسم العائلة مطلوب")]
        public string Lname { get; set; }
        [Required(ErrorMessage = " الحقل الجنس مطلوب")]
        public string Gender { get; set; }
        [Required(ErrorMessage = " الحقل تاريخ الميلاد  مطلوب")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = " الحقل الجوال مطلوب")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = " الحقل  الحالة الصحية مطلوب")]
        public string HealthStatus { get; set; }
        [Required(ErrorMessage = " الحقل جهة القدوم مطلوب")]
        public string CountryOfReturn { get; set; }
        [Required(ErrorMessage = " الحقل  المحافظة مطلوب")]
        public int? Governorate { get; set; }
        [Required(ErrorMessage = " الحقل  المدينة مطلوب")]
        public int? City { get; set; }
        [Required(ErrorMessage = " الحقل  العنوان بالتفصيل مطلوب")]
        public string Address { get; set; }
        [Required(ErrorMessage = " الحقل جهة الوصول مطلوب")]
        public int? ArrivingPointId { get; set; }
       
        [Required(ErrorMessage = " الحقل  تفاصيل جهة القدوم مطلوب")]
        public int? ArrivingPointDetailID { get; set; }
       
        [DataType(DataType.Date)]
        [Required(ErrorMessage = " الحقل  تاريخ الوصول مطلوب")]
        public DateTime? ArrivalDate { get; set; }
        [Required(ErrorMessage = " الحقل  ساعة الوصول مطلوب")]
        [DataType(DataType.Time)]
        public TimeSpan? ArrivalTime { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdatetUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool IsDeleted { get; set; } 


        public List<NationalityModel> Nationalitieslist { get; set; }
        public List<IdTypeEnumModel> IdTypeEnumList { get; set; }

        public List<GenderEnumModel> GenderEnumList { get; set; }

        public List<SelectListItem> HealthCenterList { get; set; }
        public List<SelectListItem> ArrivingPointList { get; set; }

        public List<SelectListItem> GovernateList { get; set; }

        public string FullName
        {
            get
            {

                return $"{this.Fname} {this.Sname} {this.Tname} {this.Lname}";
            }

        }


    }
}
