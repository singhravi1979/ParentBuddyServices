using System;
using Microsoft.Practices.Unity;

namespace ParentBuddyService.DependencyResolution
{
	public class Bootstrapper
	{
		public static void RegisterDependencies(IUnityContainer container)
		{
			container.RegisterTypes(AllClasses.FromLoadedAssemblies()
				, WithMappings.FromMatchingInterface, WithName.Default, null,
									null, true);
		}
	}
}
