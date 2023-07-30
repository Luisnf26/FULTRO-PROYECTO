using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using capaDatos.DataBase;
using Microsoft.Ajax.Utilities;

namespace capaNegocio.Acciones
{
    public class AccionesConsulta : AccionesBases
    {
        public List<TM_Clientes> listTM_Clientes()
        {
            return dbLibContext.TM_Clientes.ToList();
        }
        public List<TM_Contabilidad> listTM_Contabilidad()
        {
            return dbLibContext.TM_Contabilidad.ToList();
        }
        public List<TM_Empleados> listTM_Empleados()
        {
            return dbLibContext.TM_Empleados.ToList();
        }

        public List<TM_HamMaker> listTM_HamMaker()
        {
            return dbLibContext.TM_HamMaker.ToList();
        }

        public List<TM_Ingredientes> listTM_Ingredientes()
        {
            return dbLibContext.TM_Ingredientes.ToList();
        }

        public List<TM_Local> listTM_Local() 
        {
            return dbLibContext.TM_Local.ToList();
        }

        public List<TM_Menu> listTM_Menu() 
        {
            return dbLibContext.TM_Menu.ToList();
        }

        public List<TM_Pedidos> listTM_Pedidos() 
        {
            return dbLibContext.TM_Pedidos.ToList();
        }
    }
}
