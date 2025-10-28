using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class ClientesDA
    {
        public Clientes LlenarEntidad(IDataReader reader)
        {
            Clientes cliente = new Clientes();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Codigo"]))
                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
            }


            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NombreCompleto"]))
                    cliente.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Zona'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Zona"]))
                    cliente.Zona = Convert.ToString(reader["Zona"]);
            }

            return cliente;

        }
        public List<Clientes> ListaClientes()
        {
            List<Clientes> listaEntidad = new List<Clientes>();
            Clientes entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paListarClientes", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);

                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }

        // AGREGAR ESTE
        public Clientes BuscarCliente(int codigo)
        {
            Clientes cliente = null;

            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paBuscarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", codigo);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente = LlenarEntidad(reader);
                    }
                }
                conexion.Close();
            }

            return cliente;
        }

        // AGREGAR ESTE
        public void InsertarCliente(Clientes cliente)
        {
            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paInsertarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    comando.Parameters.AddWithValue("@Zona", cliente.Zona);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        // AGREGAR ESTE
        public void ActualizarCliente(Clientes cliente)
        {
            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paModificarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                    comando.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    comando.Parameters.AddWithValue("@Zona", cliente.Zona);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        // AGREGAR ESTE
        public void EliminarCliente(int codigo)
        {
            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paEliminarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", codigo);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
    }
}
