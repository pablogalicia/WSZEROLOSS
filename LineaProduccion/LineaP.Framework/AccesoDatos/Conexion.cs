using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;


namespace LineaP.Framework.AccesoDatos {
    public class Conexion {
        public static SqlConnection ObtieneConexion() {
            SqlConnection conexion;

            try {

                string ruta = (AppDomain.CurrentDomain.BaseDirectory);
                StreamReader objReader = new StreamReader(ruta + "ArchivoBD.txt");
                string sLine = "";

                sLine = objReader.ReadLine();


                if (sLine.Length != 0) {

                    string[] separadas;
                    separadas = sLine.Split('|');
                    conexion = new SqlConnection(@"Data Source=" + separadas[0] + "\\" + separadas[1] + ";Initial Catalog="+ separadas[2] + ";Persist Security Info=True;User ID=" + separadas[3] + ";Password=" + separadas[4] + "");

                } else {
                    conexion = null;
                }





            } catch (SqlException sqlExp) {
                Console.WriteLine(sqlExp);
                conexion = null;
            }

            return conexion;
        }
    }
}