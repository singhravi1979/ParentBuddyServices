using System;
using System.Collections.Generic;

namespace ParentBuddyService.ServiceContracts
{
	public interface IRepository<T>
	{
		void AddRecord(T data,string tableName);
		void AddRecords(IEnumerable<T> data,string tableName);

		bool DeleteRecords(object filterconditon,string tableName);

		IEnumerable<T> GetRecords(string tablename, string filterconditon,object parameters,int pagesize,int pagenumber,
		                   string orderbyclause);
		int GetRecordCount(string tablename, string filterconditon, object parameters);
		void UpdateRecord(string tablename,T data, string filtercondition,object parameters);

	}
}
