using System;
using Dapper;

namespace ParentBuddyService.DataAccessLayer
{
	[Table("Events")]
	public class EventPoco
	{
		[Key]
		[Column("idEvents")]
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
		public int EventRating
		{
			get;
			set;
		}
		[Column("EventStartDate")]
		public DateTime StartDate
		{
			get;
			set;
		}

		[Column("EventEndDate")]
		public DateTime EndDate
		{
			get;
			set;
		}


		[Column("ST_X(EventLocation)")]
		public double Latitude
		{
			get;
			set;
		}

		[Column("ST_Y(EventLocation)")]
		public double Longitude
		{
			get;
			set;
		}
	}
}
