using ApiMiCamioncito.Data_Y_Conexion;
using ApiMiCamioncito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiMiCamioncito.Controllers
{
    public class SolicitudController : ApiController
    {
        public List<Solicitud> Get()
        {
            return SolicitudData.VerSolicitudes();
        }

        // GET api/<controller>/5
        public Solicitud Get(int id)
        {
            return SolicitudData.ObtenerSolicitud(id);
        }

        public bool Post([FromBody] Solicitud solicitud)
        {
            return SolicitudData.RegistrarSolicitud(solicitud);
        }

        // Put api/<controller>/5
        public bool Put([FromBody] Solicitud solicitud)
        {
            return SolicitudData.ModificarSolicitud(solicitud);
        }

    }
}
