using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.AccesoDato.Core
{
    public class OpcionDA
    {
        public List<Opcion> ListarOpciones()
        {
            List<Opcion> lista = new List<Opcion>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString))
                {
                    string query = @"SELECT IdOpcion, NombreOpcion, UrlOpcion, RutaImagen, NroOrden, IdOpcionRef
                                     FROM Opcion
                                     ORDER BY NroOrden";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        conexion.Open();

                        SqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(LlenarEntidad(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al listar Opciones: " + ex.Message, ex);
            }

            return lista;
        }

        private Opcion LlenarEntidad(IDataReader reader)
        {
            Opcion opcion = new Opcion();

            if (ColumnExists(reader, "IdOpcion") && !Convert.IsDBNull(reader["IdOpcion"]))
                opcion.IdOpcion = Convert.ToInt32(reader["IdOpcion"]);

            if (ColumnExists(reader, "NombreOpcion") && !Convert.IsDBNull(reader["NombreOpcion"]))
                opcion.NombreOpcion = Convert.ToString(reader["NombreOpcion"]);

            if (ColumnExists(reader, "UrlOpcion") && !Convert.IsDBNull(reader["UrlOpcion"]))
                opcion.UrlOpcion = Convert.ToString(reader["UrlOpcion"]);

            if (ColumnExists(reader, "RutaImagen") && !Convert.IsDBNull(reader["RutaImagen"]))
                opcion.RutaImagen = Convert.ToString(reader["RutaImagen"]);

            if (ColumnExists(reader, "NroOrden") && !Convert.IsDBNull(reader["NroOrden"]))
                opcion.NroOrden = Convert.ToInt32(reader["NroOrden"]);

            if (ColumnExists(reader, "IdOpcionRef") && !Convert.IsDBNull(reader["IdOpcionRef"]))
                opcion.IdOpcionRef = Convert.ToInt32(reader["IdOpcionRef"]);

            return opcion;
        }

        private bool ColumnExists(IDataReader reader, string columnName)
        {
            DataTable schemaTable = reader.GetSchemaTable();
            schemaTable.DefaultView.RowFilter = $"ColumnName='{columnName}'";
            return (schemaTable.DefaultView.Count > 0);
        }
    }
}