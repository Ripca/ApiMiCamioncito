using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public string CapacidadCarga { get; set; }
        public string CombustiblePorKm { get; set; }
        public string Disponibilidad { get; set; }
        public string DepreciacionPorKm { get; set; }
        public string TipoCarga { get; set; }
    }
}