using NUnit.Framework;
using System;
using Microsoft.Practices.Unity;
using ParentBuddyService.DependencyResolution;
using ParentBuddyService.ServiceContracts;
using ParentBuddyService.DataAccessLayer;

namespace ParentBuddyServices.Tests
{
	[TestFixture]
	public class TestEventDataaccessService
	{
		private UnityContainer _container;
		public TestEventDataaccessService()
		{
			 _container = new UnityContainer();
			Bootstrapper.RegisterDependencies(_container);
			DataAccessServiceBootstrapper.Bootstrap(
				_container);
		}

		[Test]
		public void TestCase()
		{
			var eventdataaccessservice = _container.Resolve<IEventDataAccessService>();
			var data = eventdataaccessservice.GetAllEventsByStartandEndDate(DateTime.MinValue, new DateTime(2017,01,25,15,0,0));
			                                                               
		}
	}
}
