using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class ClientesLN : BaseLN
    {
        // Ya tienes este
        public List<Clientes> ListaClientes()
        {
            try
            {
                return new ClientesDA().ListaClientes();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        // AGREGAR ESTE
        public Clientes BuscarCliente(int codigo)
        {
            try
            {
                return new ClientesDA().BuscarCliente(codigo);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        // AGREGAR ESTE
        public void InsertarCliente(Clientes cliente)
        {
            try
            {
                new ClientesDA().InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        // AGREGAR ESTE
        public void ActualizarCliente(Clientes cliente)
        {
            try
            {
                new ClientesDA().ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        // AGREGAR ESTE
        public void EliminarCliente(int codigo)
        {
            try
            {
                new ClientesDA().EliminarCliente(codigo);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}