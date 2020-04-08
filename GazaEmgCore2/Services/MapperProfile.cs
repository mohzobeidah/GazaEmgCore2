using AutoMapper;
using GazaEmgCore2.Domain;
using GazaEmgCore2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Services
{
    public class MapperProfile: Profile
    {

        public MapperProfile()
        {
        CreateMap<QuarantinedPerson, QuarantinedPersonVM>().ReverseMap();
        }

     
    }
}
