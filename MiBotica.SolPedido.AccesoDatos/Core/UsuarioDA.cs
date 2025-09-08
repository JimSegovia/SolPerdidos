using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.AccesoDato.Core
{
    public class UsuarioDA
    {
        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("paUsuarioLista", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al consultar la BD: " + ex.Message, ex);
            }

            return listaEntidad;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("paUsuario_insertar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                        comando.Parameters.AddWithValue("@Clave", usuario.Clave); // byte[]
                        comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al insertar usuario: " + ex.Message, ex);
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("paUsuarioActualizar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                        comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                        comando.Parameters.AddWithValue("@Clave", usuario.Clave);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al actualizar usuario: " + ex.Message, ex);
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("paUsuarioEliminar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al eliminar usuario: " + ex.Message, ex);
            }
        }


        private Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario();

            if (ColumnExists(reader, "IdUsuario") && !Convert.IsDBNull(reader["IdUsuario"]))
                usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

            if (ColumnExists(reader, "CodUsuario") && !Convert.IsDBNull(reader["CodUsuario"]))
                usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);

            if (ColumnExists(reader, "Clave") && !Convert.IsDBNull(reader["Clave"]))
                usuario.Clave = (byte[])reader["Clave"];

            if (ColumnExists(reader, "Nombres") && !Convert.IsDBNull(reader["Nombres"]))
                usuario.Nombres = Convert.ToString(reader["Nombres"]);

            return usuario;
        }

        private bool ColumnExists(IDataReader reader, string columnName)
        {
            DataTable schemaTable = reader.GetSchemaTable();
            schemaTable.DefaultView.RowFilter = $"ColumnName='{columnName}'";
            return (schemaTable.DefaultView.Count > 0);
        }
    }
}
