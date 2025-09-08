using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers; // 👉 para usar la encriptación

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuarios = new UsuarioLN().ListaUsuarios();
            return View(usuarios); // Pasamos la lista a la vista
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = new UsuarioLN().ListaUsuarios().FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            return View(usuario); // Pasamos el modelo vacío a la vista
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // 🔒 Encriptar clave antes de guardar
                    usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);

                    // Guardar usuario en la BD
                    new UsuarioLN().InsertarUsuario(usuario);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear usuario: " + ex.Message);
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = new UsuarioLN().ListaUsuarios().FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                new UsuarioLN().ActualizarUsuario(usuario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar usuario: " + ex.Message);
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = new UsuarioLN().ListaUsuarios().FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                new UsuarioLN().EliminarUsuario(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar usuario: " + ex.Message);
                return View();
            }
        }
    }
}
