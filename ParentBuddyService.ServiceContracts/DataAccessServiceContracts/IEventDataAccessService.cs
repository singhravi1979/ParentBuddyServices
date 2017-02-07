using System;
using System.Collections.Generic;
using ParentBuddyService.DataContracts;

namespace ParentBuddyService.ServiceContracts
{
	public interface IEventDataAccessService
	{
		IEnumerable<EventDTO> GetAllEventsByStartandEndDate(DateTime startdate, DateTime enddate);
	}
}
