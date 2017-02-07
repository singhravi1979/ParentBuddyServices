using System;
using System.Collections.Generic;
using ParentBuddyService.DataContracts;
using ParentBuddyService.ServiceContracts;

namespace ParentBuddyServices.Domain
{
	public class EventService:IEventService
	{
		private readonly IEventDataAccessService _eventdataAccessService;
		public EventService(IEventDataAccessService eventdataAccessService)
		{
			_eventdataAccessService = eventdataAccessService;
		}

		public void AddEvent(EventDTO eventdto)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EventDTO> GetAllEventsByStartandEndDate(DateTime startdate, DateTime enddate)
		{
			return _eventdataAccessService.GetAllEventsByStartandEndDate(startdate, enddate);
		}

		public IEnumerable<EventDTO> GetAllEventsByStartandEndDateandLocation(DateTime startdate, DateTime enddate, LocationDTO location)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EventDTO> GetAllUserEventsByStartandEndDate(DateTime startdate, DateTime enddate, int userid)
		{
			throw new NotImplementedException();
		}
	}
}
