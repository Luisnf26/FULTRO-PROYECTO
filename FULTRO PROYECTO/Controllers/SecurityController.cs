using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaNegocio.Acciones;

namespace FULTRO_PROYECTO.Controllers
{
    public class SecurityController : Controller
    {

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            
            {
                // Aquí agregamos la lógica para autenticar al usuario utilizando la base de datos.
                var usuarios = new AccionesConsulta().listTM_Usuarios();

                // Verificamos si existe un usuario
                var user = usuarios.FirstOrDefault(u => u.Usuario == username && u.Contraseña == password);

                if (user != null)
                {
                    // El usuario y la contraseña son válidos, redirigir a la página de mantenimiento.
                    return RedirectToAction("Mantenimiento", "Mantenimiento", "Security");
                }
                else
                {
                    // Credenciales incorrectas, 
                    ViewBag.ErrorMessage = "Usuario o contraseña incorrectos.";
                    return View();
                }

            }
        }
        public ActionResult Logout()
        {
            return RedirectToAction("LoginAdmin");
        }

        public ActionResult Mantenimiento()
        {
            return View();
        }
    }
}