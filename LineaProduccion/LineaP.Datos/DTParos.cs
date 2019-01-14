using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineaP.Entidades;
using LineaP.Framework.AccesoDatos;
using System.Data;
using System.Data.SqlClient;

namespace LineaP.Datos {
    public class DTParos {
        public List<ProcesoParos> DTProcesoParos() {
            DataTable dt = new DataTable();
            SqlConnection connection = null;

            List<ProcesoParos> lstCat = new List<ProcesoParos>();
            try {


                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT * FROM ProcesoParos ORDER BY idProcesoParo ASC");
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows) {
                    ProcesoParos item = new ProcesoParos();

                    item.idProcesoParo = Convert.ToInt32(row["idProcesoParo"]);
                    item.nombreProceso = row["nombreProceso"].ToString();
                    lstCat.Add(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
            return lstCat;

        }
        public List<Categoria> DTCateg() {
            DataTable dt = new DataTable();
            SqlConnection connection = null;

            List<Categoria> lstCat = new List<Categoria>();
            try {


                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT * FROM Categorias order by idCategoria ASC");
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows) {
                    Categoria item = new Categoria();

                    item.idCategoria = Convert.ToInt32(row["idCategoria"]);
                    item.nombreCategoria = row["nombreCategoria"].ToString();
                    item.estatus = Convert.ToBoolean(row["estatus"].ToString());
                    lstCat.Add(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
            return lstCat;

        }
        public List<subCategorias> DTSubCateg(int idProceso) {
            DataTable dt = new DataTable();
            SqlConnection connection = null;

            List<subCategorias> lstCat = new List<subCategorias>();
            try {


                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT * FROM SubcategoriaxCategoria where idCategoria = " + idProceso + " order by idSubcategoriaxCategoria ASC");
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows) {
                    subCategorias item = new subCategorias();

                    item.idCategoria = Convert.ToInt32(row["idCategoria"]);
                    item.idSubcategoriaxCategoria = Convert.ToInt32(row["idSubcategoriaxCategoria"]);
                    item.descripcionSubcategoria = row["descripcionSubcategoria"].ToString();
                    item.idMotivoParo = Convert.ToInt32(row["idMotivoParo"]);

                    lstCat.Add(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
            return lstCat;

        }
        public List<motivosParo> DTMotivosParo(int idMotivo) {
            DataTable dt = new DataTable();
            SqlConnection connection = null;

            List<motivosParo> lstCat = new List<motivosParo>();
            try {


                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT * FROM MotivosParo where idMotivoParo = "+ idMotivo + "  order by idMotivoParo ASC");
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows) {
                    motivosParo item = new motivosParo();

                    item.idMotivoParo = Convert.ToInt32(row["idMotivoParo"]);
                    item.descripcionParo = row["descripcionParo"].ToString();
                    item.estatus = Convert.ToBoolean(row["estatus"]);

                    lstCat.Add(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
            return lstCat;

        }
        public List<linea> DTLinea() {
            DataTable dt = new DataTable();
            SqlConnection connection = null;

            List<linea> lstCat = new List<linea>();
            try {


                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT * FROM Lineas order by idLinea ASC");
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows) {
                    linea item = new linea();

                    item.idLinea = Convert.ToInt32(row["idLinea"]);
                    item.nombreLinea = row["nombreLinea"].ToString();
                    item.activo = Convert.ToBoolean(row["activo"]);
                    item.idEstatusLinea = Convert.ToInt32(row["idEstatusLinea"]);

                    lstCat.Add(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
            return lstCat;

        }
        public List<ParosLineas> DTAllParoLinea() {
            DataTable dt = new DataTable();
            SqlConnection connection = null;

            List<ParosLineas> lstCat = new List<ParosLineas>();
            try {


                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "select isNull(pl.tiempoTransacurridoParo,'') as tiempoTransacurridoParo,isNull(pl.tiempoAtencionParo,'') as tiempoAtencionParo,isNull(pl.idNivelEscalamiento,'') as idNivelEscalamiento,pl.idParoLinea,pl.idLinea,pl.fechaHoraFin,pl.fechaHoraInicio,pl.fechaHoraAtencion AS fechaHoraAtencion,isNull(pl.descripcionDetalleParo,'') AS descripcionDetalleParo,mp.idMotivoParo,mp.descripcionParo,p.idPersonal,p.nombre,el.nombreEstatus from ParosLinea pl inner join MotivosParo mp on pl.idMotivoParo = mp.idMotivoParo inner join Personal p on pl.idPersonal = p.idPersonal inner join Lineas l on pl.idLinea = l.idLinea inner join EstatusLinea el on l.idEstatusLinea = el.idEstatusLinea where pl.idParoLinea not in ( select idParoLinea from ParosLinea where fechaHoraFin <> '')");
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows) {
                    ParosLineas item = new ParosLineas();
                    item.idParoLinea = Convert.ToInt32(row["idParoLinea"]);
                    item.idLiena = Convert.ToInt32(row["idLinea"]);
                    item.fechaHoraInicio = row["fechaHoraInicio"].ToString();
                    item.fechaHoraFin = row["fechaHoraFin"].ToString();
                    item.fechaHoraAtencion = row["fechaHoraAtencion"].ToString();
                    item.descripcionDetalleParo = row["descripcionDetalleParo"].ToString();
                    item.idMotivoParo = Convert.ToInt32(row["idMotivoParo"]);
                    item.motivoParo = row["descripcionParo"].ToString();
                    item.idPersonal = Convert.ToInt32(row["idPersonal"]);
                    item.personal = row["nombre"].ToString();
                    item.idNivelEscalamiento = Convert.ToInt32(row["idNivelEscalamiento"]);
                    item.tiempoAtencionParo = Convert.ToInt32(row["tiempoAtencionParo"]);
                    item.tiempoTransacurridoParo = Convert.ToInt32(row["tiempoTransacurridoParo"]);
                    item.nombreEstatus = row["nombreEstatus"].ToString();



                    lstCat.Add(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
            return lstCat;

        }
        public bool InsertLineaParo(int idLinea, String fechaHoraInicio, int idMotivoParo, int idPersonal) {

            SqlConnection connection = null;
            bool ins;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    connection.Open();
                    SqlDataReader Resul2 = Ejecuta.ConsultaConRetorno(connection, "SELECT count(idParoLinea)+1 as idParoLinea FROM ParosLinea");
                    Resul2.Read();
                    int resultadoid2 = Resul2.GetInt32(0);
                    Int32 idaccion = resultadoid2;
                    if (idaccion==0) {
                        idaccion = (idaccion + 1);
                    }
                    connection.Close();


                    connection.Open();
                    ins = Ejecuta.ConsultaSinRetorno1(connection, "INSERT INTO ParosLinea(idParoLinea,idLinea,fechaHoraInicio,idMotivoParo,idPersonal) VALUES(" + idaccion + "," + idLinea + ",'" + fechaHoraInicio + "'," + idMotivoParo  + "," + idPersonal  + ")");
                    connection.Close();
                }

            } catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }


            return ins;
        }
        public bool ActualizaEstatusParoLinea(int idParoLinea) {
            try {
                SqlConnection connection = null;
                Boolean respuesta;

                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    respuesta = Ejecuta.ConsultaSinRetorno1(connection, "UPDATE ParosLinea SET fechaHoraAtencion ='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' WHERE idParoLinea = " + idParoLinea);
                    connection.Close();
                }
                return respuesta;
            } catch (Exception Falla) {
                throw new Exception(Falla.Message, Falla);
            }
        }
        public bool ActualizaDescripcionParoLinea(int idParoLinea,String descripcion) {
            try {
                SqlConnection connection = null;
                Boolean respuesta;

                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    respuesta = Ejecuta.ConsultaSinRetorno1(connection, "UPDATE ParosLinea SET fechaHoraFin ='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', descripcionDetalleParo ='" + descripcion + "' WHERE idParoLinea = " + idParoLinea);
                    connection.Close();
                }
                return respuesta;
            } catch (Exception Falla) {
                throw new Exception(Falla.Message, Falla);
            }
        }

    }

}
