using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LineaP.Entidades;
using LineaP.Framework.AccesoDatos;

namespace LineaP.Datos {
    public class Datos_Seguridad_Menu {

        public bool DatInsertaLectura(Int32 idSensor, Int32 idVariable, Int32 datoVariable, Int32 intidEstatusLinea) {
            try
            {

                SqlConnection connection = null;
                Boolean respuesta;
                String NumOrdenActivo = "";

                using (connection = Conexion.ObtieneConexion())
                {
                    connection.Open();

                    NumOrdenActivo = Ejecuta.EjecutarConsulta(connection, null, "SELECT NumOrden,totalPiezas,cantidadProducida,estatus,idPersonal FROM MAEOrden WHERE estatus= 1", false).Rows[0]["NumOrden"].ToString();
                    NumOrdenActivo = (NumOrdenActivo != "") ? NumOrdenActivo : "0";                   

                    respuesta = Ejecuta.ConsultaSinRetorno1(connection, "UPDATE MAEOrden SET cantidadProducida =" + datoVariable.ToString() + " WHERE NumOrden = " + NumOrdenActivo + " INSERT INTO DETOrden (NumOrden,idSensor,idVariableMedida,valorVariable,fechaHora) VALUES(" + NumOrdenActivo + "," + idSensor.ToString() + "," + idVariable.ToString() + "," + datoVariable.ToString() + ",getdate())");
                    connection.Close();
                }
                return respuesta;
            }
            catch(Exception Falla)
            {
                throw new Exception(Falla.Message, Falla);
            }
                       
        }
    }
}
