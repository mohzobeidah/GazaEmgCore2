using GazaEmgCore2.IRepository;
using GazaEmgCore2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Services
{
    public static  class RegisterService
    {

        public static void AddRepositoryServcies(this IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IQuarantinedPersonRepository, QuarantinedPersonRepository>();
            services.AddScoped<IArrivingPointRepository, ArrivingPointRepository>();
            services.AddScoped<IArrivingPointDetailRepository, ArrivingPointDetailRepository>();

            services.AddScoped<IHealthCenterRepository, HealthCenterRepository>();
            services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IMapSettingRepository, MapSettingRepository>();
        }
    }
}
