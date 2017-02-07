using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using ParentBuddyService.ServiceContracts;
using MySql.Data.MySqlClient;
using Dapper;
using System.Text;

namespace ParentBuddyService.DataAccessLayer
{
	public class MySqlRepository<T>:IRepository<T> where T:new()
	{
		private string _connectionstring;
		private readonly string _insertsqlFormat = "Insert into {0}({1}) values ({2}) ";
		private readonly string _updatesqlFormat = "Update  {0} set {1} ";
		private readonly string _deletesqlFormat = "Delete * from  {0} where {1} ";
		private readonly string _selectsqlFormat = "Select {0} from  {1} where 1=1 ";
		private readonly string _selectsqlWhereClauseFormat = "Select {0} from  {1} where 1=1 and {2} ";
		private Func<IEnumerable<dynamic>, IEnumerable<T>> parseFunc;
		public MySqlRepository()
		{
			_connectionstring = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
			parseFunc = parseitems();
		}

		public void AddRecord(T data, string tableName)
		{
			throw new NotImplementedException();
		}

		public void AddRecords(IEnumerable<T> data, string tableName)
		{
			throw new NotImplementedException();
		}

		public bool DeleteRecords(object filterconditon, string tableName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetRecords(string tablename, string filterconditon,object parameters,  int pagesize,
		                          int pagenumber,string orderbyclause)
		{
			

			using (var connection = OpenConnection())
			{

				//return connection.GetListPaged<T>(pagenumber, pagesize, filterconditon, orderbyclause, parameters);
				var sqlstring = GetMySqlSelectCommand(tablename,filterconditon);
				var data = connection.Query(sqlstring,parameters);




				return parseFunc(data);
			}
		}
		private Func<IEnumerable<dynamic>,IEnumerable<T>> parseitems()
		{
			return delegate (IEnumerable<dynamic> objparams)
		   {
				var retList = new List<T>();
			   		
				var data = new T();
			   foreach (IDictionary<string, object> row in objparams)
			   {
				   foreach (var prop in typeof(T).GetProperties())
				   {
					   string columnname = prop.Name;
					   if (prop.CustomAttributes.AsList().Exists(x => x.AttributeType == typeof(Dapper.ColumnAttribute)))
					   {
						   var customprop = prop.CustomAttributes.AsList().Find(x => x.AttributeType == typeof(ColumnAttribute));

						   columnname = customprop.ConstructorArguments[0].Value.ToString();


					   }
					   prop.SetValue(data, row[columnname]);

				   }

				   retList.Add(data);
			   }
			   return retList;
		   };
		}
		public void UpdateRecord(string tablename, T data, object filtercondition)
		{
			throw new NotImplementedException();
		}

		private IDbConnection OpenConnection()
		{
			
			var connection = new MySqlConnection(_connectionstring);
			connection.Open();

			return connection;
		}

		private void closeConnection(IDbConnection connection)
		{
			connection.Close();


		}
		

		private string GetMySqlInsertCommand(T data, string tablename)
		{
			var insertColumnnameSql = new StringBuilder();
			var insertColumnValueSql = new StringBuilder();

			foreach (var prop in data.GetType().GetProperties())
			{
				insertColumnnameSql.Append(prop.Name);
				insertColumnnameSql.Append(",");
				insertColumnValueSql.Append(getFormattedString(prop.GetValue(data)));
				insertColumnValueSql.Append(",");
			}

			return string.Format(_insertsqlFormat, tablename, insertColumnnameSql.ToString().TrimEnd(','),
			                     insertColumnValueSql.ToString().TrimEnd(','));
		}
		private string GetMySqlSelectCommand(string tablename, string filterCondition) 
		{
			var selectColumnnameSql = new StringBuilder();

			foreach (var prop in typeof(T).GetProperties())
			{
				string columnname = prop.Name;
				if (prop.CustomAttributes.AsList().Exists(x => x.AttributeType == typeof(Dapper.ColumnAttribute)))
				{
					var customprop = prop.CustomAttributes.AsList().Find(x => x.AttributeType == typeof(ColumnAttribute));

					columnname = customprop.ConstructorArguments[0].Value.ToString();
				}
				                

				selectColumnnameSql.Append(columnname);
				selectColumnnameSql.Append(',');

			}
			if(string.IsNullOrEmpty(filterCondition))
					return string.Format(_selectsqlFormat,selectColumnnameSql.ToString().TrimEnd(','), tablename);
			else
				return string.Format(_selectsqlWhereClauseFormat, selectColumnnameSql.ToString().TrimEnd(','), tablename, filterCondition);
				
		}

		private string getFormattedString(object data)
		{

			switch (data.GetType().ToString())
			{
				case "System.int":
				case "System.double":
				case "System.float":

					return data.ToString();
				case "System.string":
				case "System.DateTime":
					return "'" + data.ToString() + "'";
				default:
					return data.ToString();
			}

		}

		public int GetRecordCount(string tablename, string filterconditon, object parameters)
		{
			throw new NotImplementedException();
		}

		public void UpdateRecord(string tablename, T data, string filtercondition, object parameters)
		{
			throw new NotImplementedException();
		}
	}
}
