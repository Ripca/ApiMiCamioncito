using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Models
{
    public class Conductor
    {
        public int IdConductor { get; set; }
        public string NombreConductor { get; set; }
        public string Viaticos { get; set; }
        public string GastosAdicionales { get; set; }
        public string Disponibilidad { get; set; }
    }
}