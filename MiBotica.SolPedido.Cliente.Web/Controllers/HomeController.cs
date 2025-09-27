using MiBotica.SolPedido.AccesoDato.Core;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {   //RECUPERAR LA LISTA DE OPCIONES
            OpcionDA opcionDA = new OpcionDA();
            VariablesWeb.gOpciones = opcionDA.ListaOpciones();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}