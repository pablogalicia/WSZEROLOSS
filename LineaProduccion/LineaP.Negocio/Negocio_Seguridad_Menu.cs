using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineaP.Datos;
using LineaP.Entidades;

namespace LineaP.Negocio {
    public class Negocio_Seguridad_Menu {

        readonly Datos_Seguridad_Menu DatosMenu = new Datos_Seguridad_Menu();

        public bool NegInsertaLectura(string lectura){
            try
            {
                string[] separadas;

                separadas = lectura.Split('|');

                Int32 idSensor = Convert.ToInt32(separadas[0]);
                Int32 idVariable = Convert.ToInt32(separadas[1]);
                Int32 datoVariable = Convert.ToInt32(separadas[2]);
                Int32 intidEstatusLinea = Convert.ToInt32(separadas[3]);

                return DatosMenu.DatInsertaLectura(idSensor, idVariable, datoVariable, intidEstatusLinea);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
