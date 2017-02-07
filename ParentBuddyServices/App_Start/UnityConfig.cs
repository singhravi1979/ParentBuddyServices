using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ParentBuddyService.DependencyResolution;
using ParentBuddyService.DataAccessLayer;

namespace ParentBuddyServices
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			Bootstrapper.RegisterDependencies(container);
           
			DataAccessServiceBootstrapper.Bootstrap(
				container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}