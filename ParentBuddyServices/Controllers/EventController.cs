using System;
using System.Web.Http;
using ParentBuddyService.DataContracts;
using ParentBuddyService.ServiceContracts;

namespace ParentBuddyServices
{
	public class EventController:ApiController
	{
		private readonly IEventService _eventService;
		
		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		[HttpPost]
		[ActionName("GetAllEventsByStartandEndDate")]
		public IHttpActionResult GetAllEventsByStartandEndDate(EventRequestPresentationModel eventrequest)
		{
			
			
			var data = _eventService.GetAllEventsByStartandEndDate(eventrequest.StartDate, eventrequest.EndDate);


			return new EventResponsePresentationModel(data);
		}
	}
}
