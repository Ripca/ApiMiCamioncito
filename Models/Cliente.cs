using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Models
{
        public class Cliente
        {
            public int IdCliente { get; set; }
            public string NombreCliente { get; set; }
            public string Correo { get; set; }
            public string DPI { get; set; }
        }
}