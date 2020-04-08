using GazaEmgCore2.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class QuarantinedPerson
    {
        public int Id { get; set; }
        public string IdentityNo { get; set; }
        public IdTypeEnum IDType { get; set; }

        public Nationality nationality { get; set; }
       
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Tname { get; set; }
        public string Lname { get; set; }
        public GenderEnum gender{ get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNo { get; set; }
        public string HealthStatus { get; set; }
     
        public int Governorate { get; set; }
        [ForeignKey(nameof(Governorate))]
        public Governorate Governorates { get; set; }
        public int City { get; set; }
        [ForeignKey(nameof(Governorate))]
        public City Cities { get; set; }
        public string Address { get; set; }
        public int ArrivingPointId{ get; set; }
        [ForeignKey(nameof(ArrivingPointId))]
        public ArrivingPoint ArrivingPoint { get; set; }
        public int ArrivingPointDetailID { get; set; }
        [ForeignKey(nameof(ArrivingPointDetailID))]
        public ArrivingPointDetail ArrivingPointDetails { get; set; }
        public DateTime ArrivalDate { get; set; }


        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdatetUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool IsDeleted { get; set; }


        public string CountryOfReturn { get; set; }



        public string FullName {
            get
            {

                return $"{this.Fname} {this.Sname} {this.Tname} {this.Lname}";
            }
        
        }


    }
}
