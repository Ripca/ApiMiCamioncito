using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Models
{
    public class Ayudante
    {
        public int IdAyudante { get; set; }
        public string NombreAyudante { get; set; }
        public string Viaticos { get; set; }
        public string GastosAdicionales { get; set; }
        public string Disponibilidad { get; set; }
    }
}