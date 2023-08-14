using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo
{
    public class mCliente
    {
        public string nombre {get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public int local_id { get; set;}
        public int pedidosID { get; set; }

        public mCliente() { }

        public mCliente(string nombre, string apellido, string direccion, string telefono, string correo_electronico, int local_id, int pedidosID)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo_electronico = correo_electronico;
            this.local_id = local_id;
            this.pedidosID = pedidosID;
        }   
    }
}
