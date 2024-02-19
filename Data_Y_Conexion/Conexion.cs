using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Data_Y_Conexion
{
    public class Conexion
    {
        public static readonly string RutaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

    }
}