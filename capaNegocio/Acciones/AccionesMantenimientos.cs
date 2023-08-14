using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using capaDatos.DataBase;
using capaModelo;

namespace capaNegocio.Acciones
{
    public class AccionesMantenimientos : AccionesBases
    {

        public string crearHamburguesas(mMenu menu)
        {
            string resultado = "";
            try
            {
                TM_Menu registrar = new TM_Menu();

                registrar = new TM_Menu()
                {
                    Bebidas = menu.bebidas,
                    Extras = menu.extras,
                    Hamburguesas = menu.hamburgues,
                    local_id = menu.localID,
                    Postres = menu.postres

                };
                dbLibContext.TM_Menu.InsertOnSubmit(registrar);
                dbLibContext.SubmitChanges();


                resultado = "Exito";
            }
            catch 
            {
                resultado = "Error";
                
            }

            return resultado;
        }

        public string crearCliente(mCliente cliente)
        {
            string resultado = "";
            try
            {
                TM_Clientes registrar_cliente = new TM_Clientes();

                registrar_cliente = new TM_Clientes()
                {
                    nombre = cliente.nombre,
                    apellido = cliente.apellido,
                    direccion = cliente.direccion,
                    telefono = cliente.telefono,
                    correo_electronico = cliente.correo_electronico,
                    local_id = cliente.local_id,

                };
                dbLibContext.TM_Clientes.InsertOnSubmit(registrar_cliente);
                dbLibContext.SubmitChanges();


                resultado = "Exito";
            }
            catch
            {
                resultado = "Error";

            }

            return resultado;
        }


        public string crearContabilidad(mContabilidad contabilidad)
        {
            string resultado = "";
            try
            {
                TM_Contabilidad registrar_contabilidad = new TM_Contabilidad();

                registrar_contabilidad = new TM_Contabilidad()
                {
                    fecha = contabilidad.fecha.Value,
                    descripcion = contabilidad.descripcion,
                    ingresos = contabilidad.ingresos,
                    gastos = contabilidad.gastos,
                    local_id = contabilidad.local_id,

                };
                dbLibContext.TM_Contabilidad.InsertOnSubmit(registrar_contabilidad);
                dbLibContext.SubmitChanges();


                resultado = "Exito";
            }
            catch
            {
                resultado = "Error";

            }

            return resultado;
        }

    }
}
