using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using APCP2.Data;
using APCP2.Repositories;
using APCP2.Services;
using Unity.AspNet.Mvc;
using Unity;

namespace APCP2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Dependencias Proyecto Repository
            var container = new UnityContainer();
            container.RegisterType<DbContext, TasksEntities>();
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryTask<>));
            container.RegisterType<IServicesBase, TaskService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
