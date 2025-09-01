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
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al consultar la BD: " + ex.Message, ex);
            }

            return listaEntidad;
        }

        private Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario();

            // IdUsuario
            if (ColumnExists(reader, "IdUsuario") && !Convert.IsDBNull(reader["IdUsuario"]))
                usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

            // CodUsuario
            if (ColumnExists(reader, "CodUsuario") && !Convert.IsDBNull(reader["CodUsuario"]))
                usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);

            // Clave
            if (ColumnExists(reader, "Clave") && !Convert.IsDBNull(reader["Clave"]))
                usuario.Clave = (byte[])reader["Clave"];

            // Nombres
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
