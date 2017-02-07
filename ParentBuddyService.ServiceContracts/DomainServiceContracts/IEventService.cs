using System;
using System.Collections.Generic;
using ParentBuddyService.DataContracts;

namespace ParentBuddyService.ServiceContracts
{
	public interface IEventService
	{
		IEnumerable<EventDTO> GetAllEventsByStartandEndDate(DateTime startdate, DateTime enddate);

		IEnumerable<EventDTO> GetAllEventsByStartandEndDateandLocation(DateTime startdate, DateTime enddate,
		                                                               LocationDTO location);

		IEnumerable<EventDTO> GetAllUserEventsByStartandEndDate(DateTime startdate, DateTime enddate,
		                                                        int userid);

		void AddEvent(EventDTO eventdto);


	}
}
