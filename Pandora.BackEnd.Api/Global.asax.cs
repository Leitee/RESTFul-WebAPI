﻿using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pandora.BackEnd.Api
{
    public class WebApiApplication : HttpApplication
    {
#if DEBUG
        string connString = ConfigurationManager.ConnectionStrings["DebugConnection"].ConnectionString;
#else
        string connString = ConfigurationManager.ConnectionStrings["ReleaseConnection"].ConnectionString;
#endif


        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Start SQL Dependency
            SqlDependency.Start(connString);
        }

        protected void Application_Stop()
        {
            //Stop SQL dependency
            SqlDependency.Stop(connString);
        }
    }
}