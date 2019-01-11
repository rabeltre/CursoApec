using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PrimeraApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["CantidadUsuarios"] = 3400;

            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            int Cantidad = int.Parse(Application["CantidadUsuarios"].ToString());
            Cantidad--;
            Application["CantidadUsuarios"] = Cantidad;
            Application.UnLock();
        }
        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            int Cantidad = int.Parse(Application["CantidadUsuarios"].ToString());
            Cantidad++;
            Application["CantidadUsuarios"] = Cantidad;
            Application.UnLock();

        }
    }
}