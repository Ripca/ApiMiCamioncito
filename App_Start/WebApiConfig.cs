using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;   //Este también tuviste que instalarlo
using System.Web.Http.Cors;
//Estas usando esa libreria:System.Web.Http.Cors, pero primero tuviste que instalar el paquete:Microsoft.AspNet.WebApi.Cors  

namespace ApiMiCamioncito
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            //ESTAS DOS LINEAS DE ABAJO SON MUUUY IMPORTANTES, GRACIAS A ELLAS SE PUEDEN HACER SOLICITUDES A LA API DE CUALQUIER LADO
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
