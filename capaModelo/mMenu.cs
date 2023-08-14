using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo
{
    public class mMenu
    {
        public string hamburgues { get; set; }
        public string bebidas { get; set; }
        public string postres { get; set; }
        public string extras { get; set; }
        public int localID { get; set; }

        public mMenu() { }

        public mMenu(string hamburgues, string bebidas, string postres, string extras, int localID)
        {
            this.hamburgues = hamburgues;
            this.bebidas = bebidas;
            this.postres = postres;
            this.extras = extras;
            this.localID = localID;
        }   
    }
}
