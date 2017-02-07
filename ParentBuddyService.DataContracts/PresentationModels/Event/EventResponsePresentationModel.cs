using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace ParentBuddyService.DataContracts
{
	public class EventResponsePresentationModel:BaseResponsePresentationModel
	{
		public IEnumerable<EventDTO> Events { get; set; }

		public EventResponsePresentationModel(dynamic data) : base((object)data)
		{
			Events = data;
		}


	}
}
