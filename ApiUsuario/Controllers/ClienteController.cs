using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;

namespace ApiUsuario.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        // Obtiene todos los clientes desde la BD
        public IEnumerable<Clientes> Get()
        {
            List<Clientes> cliente = new List<Clientes>();
            cliente = new ClientesLN().ListaClientes();
            return cliente;
        }

        // GET: api/Cliente/5
        // Obtiene un cliente específico por ID desde la BD
        public Clientes Get(int id)
        {
            Clientes cliente = new ClientesLN().BuscarCliente(id);
            return cliente;
        }

        // POST: api/Cliente
        // Inserta un nuevo cliente en la BD
        public IHttpActionResult Post([FromBody] Clientes value)
        {
            try
            {
                new ClientesLN().InsertarCliente(value);
                return Ok("Cliente creado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody] Clientes value)
        {
            try
            {
                // ASEGÚRATE DE QUE EL OBJETO TENGA EL ID CORRECTO
                if (value == null)
                {
                    return BadRequest("El cliente no puede ser nulo");
                }

                value.Codigo = id; // Fuerza el ID del parámetro de la URL
                new ClientesLN().ActualizarCliente(value);
                return Ok("Cliente actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // DELETE: api/Cliente/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                new ClientesLN().EliminarCliente(id);
                return Ok("Cliente eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}