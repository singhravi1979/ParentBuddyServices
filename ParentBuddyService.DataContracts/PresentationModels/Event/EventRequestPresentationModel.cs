using System;
namespace ParentBuddyService.DataContracts
{
	public class EventRequestPresentationModel:BaseRequestPresentationModel
	{
		public int EventId
		{
			get;
			set;
		}



		public DateTime StartDate
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public EventRequestPresentationModel()
		{
		}
	}
}
