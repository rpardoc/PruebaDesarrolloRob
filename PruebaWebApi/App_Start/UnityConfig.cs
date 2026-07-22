using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Lifetime;

using DATOS.Interfaces;
using DATOS.Repositories;

using PruebaWebApi.Interfaces;
using PruebaWebApi.Services;

namespace PruebaWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {

            var container = new UnityContainer();

            container.RegisterType
            <IRegionRepository, RegionRepository>();


            container.RegisterType
            <IComunaRepository, ComunaRepository>();



            container.RegisterType
            <IRegionService, RegionService>();



            GlobalConfiguration.Configuration.DependencyResolver =
            new UnityDependencyResolver(container);

        }
    }
}