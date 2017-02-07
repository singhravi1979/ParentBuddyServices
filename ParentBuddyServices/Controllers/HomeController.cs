using System;
using System.Web.Http;
namespace ParentBuddyServices
{
	public class HomeController : ApiController
	{
		public HomeController()
		{
		}

		[HttpGet]
		public string GetData()
		{
			return "Hello World";
		}
	}
}
