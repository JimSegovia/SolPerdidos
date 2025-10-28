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

        // GET: Cliente/Create
        public ActionResult Create()
        {
            Clientes cliente = new Clientes();
            return View(cliente);
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Clientes collection)
        {
            string metodo = "Cliente"; // refiere al controlador de la Api
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear(); // borra datos anteriores de la cabecera
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                    cliente.Encoding = UTF8Encoding.UTF8; // tipo de decodificación
                    // Convierte el objeto Cliente a formato JSON
                    var clienteJson = JsonConvert.SerializeObject(collection);
                    // Construye la ruta completa de la API
                    string rutacompleta = rutaApi + metodo;
                    // Envía los datos a la API usando el método POST
                    var resultado = cliente.UploadString(new Uri(rutacompleta), "POST", clienteJson);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Captura el mensaje de error para depuración
                var mensaje = ex.Message;
                // Opcionalmente puedes agregar el error al ModelState
                ModelState.AddModelError("", "Error al crear el cliente: " + mensaje);
                return View(collection);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            string metodo = "Cliente"; //refiere al controlador de la Api
            Clientes entCli = new Clientes();

            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear(); // borra datos anteriores de la cabecera
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                    cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación

                    // Construye la ruta con el ID del cliente a editar
                    string rutacompleta = rutaApi + metodo + "/" + id;

                    // Descarga los datos del cliente específico desde la API
                    var data = cliente.DownloadString(new Uri(rutacompleta));

                    // Deserializa los datos JSON a un objeto Clientes
                    entCli = JsonConvert.DeserializeObject<Clientes>(data);
                }
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                ModelState.AddModelError("", "Error al obtener el cliente: " + mensaje);
            }

            return View(entCli);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes collection)
        {
            string metodo = "Cliente"; //refiere al controlador de la Api

            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear(); // borra datos anteriores de la cabecera
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                    cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación

                    // Convierte el objeto Cliente modificado a JSON
                    var clienteJson = JsonConvert.SerializeObject(collection);

                    // Construye la ruta completa con el ID
                    string rutacompleta = rutaApi + metodo + "/" + id;

                    // Envía los datos usando el método PUT para actualizar
                    var resultado = cliente.UploadString(new Uri(rutacompleta), "PUT", clienteJson);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                ModelState.AddModelError("", "Error al editar el cliente: " + mensaje);
                return View(collection);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            string metodo = "Cliente"; //refiere al controlador de la Api
            Clientes entCli = new Clientes();

            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear(); // borra datos anteriores de la cabecera
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                    cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación

                    // Construye la ruta con el ID del cliente a eliminar
                    string rutacompleta = rutaApi + metodo + "/" + id;

                    // Descarga los datos del cliente para mostrarlos antes de eliminar
                    var data = cliente.DownloadString(new Uri(rutacompleta));

                    // Deserializa los datos JSON a un objeto Clientes
                    entCli = JsonConvert.DeserializeObject<Clientes>(data);
                }
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                ModelState.AddModelError("", "Error al obtener el cliente: " + mensaje);
            }

            return View(entCli);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ActionName("Delete")] // Importante: esto permite que ambos métodos se llamen "Delete"
        public ActionResult DeleteConfirmed(int id)
        {
            string metodo = "Cliente"; //refiere al controlador de la Api

            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear(); // borra datos anteriores de la cabecera
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                    cliente.Encoding = UTF8Encoding.UTF8;// tipo de decodificación

                    // Construye la ruta completa con el ID
                    string rutacompleta = rutaApi + metodo + "/" + id;

                    // Envía la petición DELETE a la API
                    var resultado = cliente.UploadString(new Uri(rutacompleta), "DELETE", "");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                ModelState.AddModelError("", "Error al eliminar el cliente: " + mensaje);
                return RedirectToAction("Index");
            }
        }
    }
}