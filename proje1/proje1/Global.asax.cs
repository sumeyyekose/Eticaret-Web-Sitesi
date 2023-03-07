using proje1.Entity;
using proje1.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace proje1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new VeriBaslatici());
            Database.SetInitializer(new IdentityInitializer());
            //Database.SetInitializer<IdentityDataContext>(null);
            //Database.SetInitializer<IdentityDataContext>(new DropCreateDatabaseIfModelChanges<IdentityDataContext>());


        }
    }
}
