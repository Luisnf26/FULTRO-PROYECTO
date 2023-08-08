using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using capaDatos.DataBase;
using capaNegocio;
using capaNegocio.Acciones;
using static capaNegocio.Acciones.AccionesConsulta;

namespace FULTRO_PROYECTO.Controllers
{
    public class SecurityController : Controller
    {

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string username, string password)
        {
            
            {
                // Aquí agregamos la lógica para autenticar al usuario utilizando la base de datos.
                var usuarios = new AccionesConsulta().listTM_Usuarios();

                // Verificamos si existe un usuario
                var user = usuarios.FirstOrDefault(u => u.Usuario == username && u.Contraseña == password);

                if (user != null)
                {
                    // El usuario y la contraseña son válidos, redirigir a la página de mantenimiento.
                    return RedirectToAction("Mantenimiento", "Security");
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

        public class MantenimientoView
        {

            public List<TM_Clientes> Clientes { get; set; }
            public List<TM_Contabilidad> Contabilidad { get; set; }
            public List<TM_Empleados> Empleados { get; set; }
            public List<TM_Local> Local { get; set; }
            public List<TM_Ingredientes> Ingredientes { get; set; }
            public List<TM_Menu> Menu { get; set; }
            public List<TM_Pedidos> Pedidos { get; set; }
        }
        public ActionResult Mantenimiento()
        {
            using (var db = new DataClasses1DataContext())
            {
                var clientes = db.TM_Clientes.ToList();
                var contabilidad = db.TM_Contabilidad.ToList();
                var empleados = db.TM_Empleados.ToList();
                var local = db.TM_Local.ToList();
                var ingredientes = db.TM_Ingredientes.ToList();
                var menu = db.TM_Menu.ToList();
                var pedidos = db.TM_Pedidos.ToList();

                var model = new MantenimientoView
                {
                    Clientes = clientes,
                    Contabilidad = contabilidad,
                    Empleados = empleados,
                    Local = local,
                    Ingredientes = ingredientes,
                    Menu = menu,
                    Pedidos = pedidos
                };

                return View(model);
            }
        }
    }
}