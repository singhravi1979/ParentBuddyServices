using System;
namespace ParentBuddyService.DataContracts
{
	public class EventDTO
	{
		public int EventId
		{
			get;
			set;
		}

		public string EventName
		{
			get;
			set;
		}

		public int EventType
		{
			get;
			set;
		}

		public string EventDescription
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



		public double Latitude
		{
			get;
			set;
		}


		public double Longitude
		{
			get;
			set;
		}
		public int EventRating
		{
			get;
			set;
		}
	}
}
