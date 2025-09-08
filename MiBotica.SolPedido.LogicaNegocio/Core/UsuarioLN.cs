using MiBotica.SolPedido.AccesoDato.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class UsuarioLN : BaseLN
    {
        UsuarioDA objUsuarioDA = new UsuarioDA();

        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return objUsuarioDA.ListaUsuarios();
            }
            catch (Exception ex)
            {
                Log.Error("Error en ListaUsuarios", ex);
                throw;
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                objUsuarioDA.InsertarUsuario(usuario);
            }
            catch (Exception ex)
            {
                Log.Error("Error en InsertarUsuario", ex);
                throw;
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                objUsuarioDA.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                Log.Error("Error en ActualizarUsuario", ex);
                throw;
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                objUsuarioDA.EliminarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                Log.Error("Error en EliminarUsuario", ex);
                throw;
            }
        }

    }
}
