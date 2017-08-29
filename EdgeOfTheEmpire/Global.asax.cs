using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using EdgeOfTheEmpire.DTOs;
using EdgeOfTheEmpire.Models;

namespace EdgeOfTheEmpire
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new WebAPIEdgeContextInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Career, CareerDto>()
                    .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name));
                cfg.CreateMap<Skill, SkillDto>()
                    .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name));
                cfg.CreateMap<Specialization, SpecializationDto>()
                    .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name));
        });            
        }
    }
}
