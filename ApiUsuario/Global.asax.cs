using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MiBotica.SolPedido.Entidades.Core;

namespace ApiUsuario
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Variables.ListaClientes = new List<Cliente>();
            Variables.ListaClientes.Add(new Cliente() { Codigo = 1, NombreCompleto = "Ricaardo Gutarra", Zona = "Callao" });
            Variables.ListaClientes.Add(new Cliente() { Codigo = 2, NombreCompleto = "David Espinoza", Zona = "Jesus Maria" });
            Variables.ListaClientes.Add(new Cliente() { Codigo = 3, NombreCompleto = "Victor Hidalgo", Zona = "San Martin" });
            Variables.ListaClientes.Add(new Cliente() { Codigo = 4, NombreCompleto = "Gladys Gutierrez", Zona = "Pueblo Libre" });
            Variables.ListaClientes.Add(new Cliente() { Codigo = 5, NombreCompleto = "Mariza Zegarra", Zona = "San Juan" });

        }
    }
}