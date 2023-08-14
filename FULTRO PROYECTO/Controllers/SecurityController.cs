using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using capaDatos.DataBase;
using capaModelo;
using capaNegocio;
using capaNegocio.Acciones;

using static capaNegocio.Acciones.AccionesConsulta;

namespace FULTRO_PROYECTO.Controllers
{
    public class SecurityController : Controller
    {


        AccionesMantenimientos accionMantenimientos = new AccionesMantenimientos();
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

            public string SelectedTable { get; set; }
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
                    Pedidos = pedidos,
       
                };

                return View(model);
            }
        }



        public class AgregarMenuView
        {
            public string Hamburguesas { get; set; }
            public string Bebidas { get; set; }
            public string Postres { get; set; }
            public string Extras { get; set; }
            public int LocalId { get; set; }

            // model de clientes
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string direccion { get; set; }
            public string telefono { get; set; }
            public string correo_electronico { get; set; }
            public int local_id { get; set; }
            public int pedidosID { get; set; }

            // model de contabilidad

            public DateTime fecha { get; set; }
            public string descripcion { get; set; }
            public decimal ingresos { get; set; }
            public decimal gastos { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMenu(AgregarMenuView model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataClasses1DataContext())
                {
                    mMenu datos = new mMenu() 
                    {
                        bebidas = model.Bebidas,
                        extras = model.Extras,  
                        hamburgues = model.Hamburguesas,
                        localID = model.LocalId,    
                        postres = model.Postres
                    
                    };

                    accionMantenimientos.crearHamburguesas(datos);


                }

                // Redirigir a la vista de mantenimiento después de agregar el nuevo menú.
                return RedirectToAction("Mantenimiento");
            }

            // Si el modelo no es válido, regresar a la vista de mantenimiento para mostrar los errores de validación.
            return View("Mantenimiento", new MantenimientoView
            {
                Menu = new List<TM_Menu>(),
            });
        }

        // agregar cliente

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarCliente(AgregarMenuView model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataClasses1DataContext())
                {
                    mCliente datos = new mCliente()
                    {
                        nombre = model.nombre,
                        apellido = model.apellido,
                        direccion = model.direccion,
                        telefono = model.telefono,
                        correo_electronico = model.correo_electronico,
                        local_id = model.local_id,

                    };

                    accionMantenimientos.crearCliente(datos);


                }

                // Redirigir a la vista de mantenimiento después de agregar el nuevo menú.
                return RedirectToAction("Mantenimiento");
            }

            // Si el modelo no es válido, regresar a la vista de mantenimiento para mostrar los errores de validación.
            return View("Mantenimiento", new MantenimientoView
            {
                Clientes = new List<TM_Clientes>(),
            });
        }

        //agregar contabilidad

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarContabilidad(AgregarMenuView model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataClasses1DataContext())
                {
                    mContabilidad datos = new mContabilidad()
                    {
                        fecha = model.fecha,
                        descripcion = model.descripcion,
                        ingresos = model.ingresos,
                        gastos = model.gastos,
                        local_id = model.local_id,

                    };

                    accionMantenimientos.crearContabilidad(datos);

                }

                // Redirigir a la vista de mantenimiento después de agregar el nuevo menú.
                return RedirectToAction("Mantenimiento");
            }

            // Si el modelo no es válido, regresar a la vista de mantenimiento para mostrar los errores de validación.
            return View("Mantenimiento", new MantenimientoView
            {
                //Clientes = new List<TM_Contabilidad>(),
            });
        }




        [HttpPost]
        public ActionResult Mantenimiento(string Tabla)
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
                    Pedidos = pedidos,
                    SelectedTable = Tabla
                };

                return View(model);
            }
        }
    }
}