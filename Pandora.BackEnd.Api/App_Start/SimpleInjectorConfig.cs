﻿using Pandora.BackEnd.Business.Concrets;
using Pandora.BackEnd.Business.Contracts;
using Pandora.BackEnd.Data.Concrets;
using Pandora.BackEnd.Data.Contracts;
using Pandora.BackEnd.Data.Helpers;
using Pandora.BackEnd.Reports;
using Pandora.BackEnd.Reports.Contracts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Pandora.BackEnd.Api
{
    public static class SimpleInjectorConfig
    {
        public static SimpleInjectorWebApiDependencyResolver Register(Container container)
        {
            // Create the container as usual.
            if (container == null)
                container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();// new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:

            //Repository
            container.Register<IRepositoryProvider, RepositoryProvider>(Lifestyle.Scoped);
            container.Register<IAuthRepository, AuthRepository>(Lifestyle.Scoped);
            container.Register<IRolRepository, RolRepository>(Lifestyle.Scoped);
            container.Register<RepositoryFactories, RepositoryFactories>(Lifestyle.Singleton);

            //Unit of Work
            container.Register<IApplicationUow, ApplicationUow>(Lifestyle.Scoped);
            container.Register<IApplicationDbContext, ApplicationDbContext>(Lifestyle.Scoped);            

            //Report Services
            container.Register<IEmployeeReportSVC, ReportSVC>(Lifestyle.Scoped);

            //Bussines Services
            container.Register<IEmployeeSVC, EmployeeSVC>(Lifestyle.Scoped);


            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            return new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}