using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Application.AutoMapper;
using AutoMapper;

namespace PhukienDT
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public class AutoMapperConfiguration
		{
			public static void Configure()
			{
				Mapper.Initialize(x =>
				{
					x.AddProfile<DomainToViewModelMappingProfile>();
					x.AddProfile<ViewModelToDomainMappingProfile>();
				});

				Mapper.Configuration.AssertConfigurationIsValid();
			}
		}
		protected void Application_Start()
		{
			Database.SetInitializer(new Data.EF.DbInitializer());
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AutoMapperConfiguration.Configure();
			Bootstrapper.Initialise();
		}
	}
}
