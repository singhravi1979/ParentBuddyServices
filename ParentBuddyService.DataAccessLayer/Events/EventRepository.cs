using System;
namespace ParentBuddyService.DataAccessLayer
{
	public class EventRepository:MySqlRepository<EventPoco>
	{
		public EventRepository()
		{
		}
	}
}
