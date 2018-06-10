using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CRMProject.BLL.Infrastructure;
using CRMProject.Util;
using Ninject;
using Ninject.Web.Mvc;
using Ninject.Syntax;

namespace CRMProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule uowModule = new NinjectServiceModule();
            NinjectModule servicesModule = new BLLServicesModule();
            var kernel = new StandardKernel(uowModule, servicesModule);
            kernel.Unbind<ModelValidatorProvider>();                                            // disable Ninject model validator
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
