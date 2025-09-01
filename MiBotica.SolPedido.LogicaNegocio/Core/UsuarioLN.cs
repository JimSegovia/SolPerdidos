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
    }
}
