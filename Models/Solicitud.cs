using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Models
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        //Si da conflicto cambialo a string y varchar, en caso extremo vas a poner la hora de forma manual en el apartado de la hora 
        public DateTime FechaSolicitud { get; set; }
        public int IdCliente { get; set; }
        public int IdConductor { get; set; }
        public int IdAyudante { get; set; }
        public int IdVehiculo { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string EstadoSolicitud { get; set; }
        public double PrecioTotal { get; set; }
    }
}