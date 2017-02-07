using System;
using System.Collections.Generic;
using AutoMapper;
using ParentBuddyService.DataContracts;
using ParentBuddyService.ServiceContracts;

namespace ParentBuddyService.DataAccessLayer
{
	public class EventDataAccessService:IEventDataAccessService
	{
		private readonly EventRepository _eventrepository;
		private readonly string EventTableName="Events";
		private readonly IMapper _mapper;
		public EventDataAccessService(EventRepository eventrepository,IMapper mapper)
		{
			_eventrepository = eventrepository;
			_mapper = mapper;
		}

		public IEnumerable<EventDTO> GetAllEventsByStartandEndDate(DateTime startdate, DateTime enddate)
		{
			var data= _eventrepository.GetRecords(EventTableName, " eventstartdate >= @startdate and eventenddate <= @enddate", new { startdate=startdate,enddate=enddate }, 
			                                      100, 1, string.Empty);


			return _mapper.Map<IEnumerable<EventPoco>, IEnumerable<EventDTO>>(data);

		}
	}
}
