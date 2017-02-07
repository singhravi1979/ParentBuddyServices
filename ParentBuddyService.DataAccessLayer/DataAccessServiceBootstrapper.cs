using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using ParentBuddyService.DataAccessLayer;
using ParentBuddyService.DataContracts;
using ParentBuddyService.ServiceContracts;

namespace ParentBuddyService.DataAccessLayer
{
	public class DataAccessServiceBootstrapper
	{
		static void HandleAction(IMapperConfigurationExpression obj)
		{
			obj.CreateMap<EventPoco, EventDTO>();
			obj.CreateMap<EventDTO, EventPoco>();
		}

		public DataAccessServiceBootstrapper()
		{
		}

		public static void Bootstrap(IUnityContainer container)
		{
			var config=new AutoMapper.MapperConfiguration(HandleAction);
			var mapper = new AutoMapper.Mapper(config);

			container.RegisterInstance<IMapper>(mapper);
			Dapper.SimpleCRUD.SetDialect(Dapper.SimpleCRUD.Dialect.MySQL);
		}
	}
}
