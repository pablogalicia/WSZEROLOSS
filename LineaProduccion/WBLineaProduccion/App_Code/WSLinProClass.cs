using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using LineaP.Negocio;
using LineaP.Entidades;


[System.Web.Script.Services.ScriptService]

public class WSLinProClass : System.Web.Services.WebService {
    
    readonly Negocio_Seguridad_Menu Negocio = new Negocio_Seguridad_Menu();

    [WebMethod]
    public bool InsertaLectura(string lectura) {
        try
        {
            return Negocio.NegInsertaLectura(lectura);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }

    [WebMethod]
    public DateTime RetornaFechayHoraServidor()
    {
        try
        {
            return DateTime.Now;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }
}

