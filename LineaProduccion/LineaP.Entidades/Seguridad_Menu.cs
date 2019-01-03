using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaP.Entidades {
    public class Seguridad_Menu {

        public int idMenu { get; set; }
        public int idPadre { get; set; }
        public int idHijo { get; set; }
        public string nombreMenu { get; set; }
        public string descripcionMenu { get; set; }
        public string liga { get; set; }
        public string icono { get; set; }
        public bool estatus { get; set; }


    }
}
