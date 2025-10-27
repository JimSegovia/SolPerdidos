using MiBotica.SolPedido.Entidades.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ClienteController : Controller
    {
        string rutaApi = "https://localhost:44343/api/";// define la ruta de la Api
        string jsonMediaType = "application/json"; // define el tipo de dato
        // GET: Clientes
        public ActionResult Index()
        {
            string metodo = "Cliente"; //refiere al controlador del la Api
            string accion = "Get"; // refiere a la Accion de que se ejecuta
            List<Clientes> lista = new List<Clientes>();
            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear(); // borra datos anterioes de la cabecera
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación textos en chino ñ y otros
                string rutacompleta = rutaApi + metodo;
                var data = cliente.DownloadString(new Uri(rutacompleta));
                lista = JsonConvert.DeserializeObject<List<Clientes>>(data);
            }
            return View(lista);
        }
    }
}