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
    public class VehiculoController : ApiController
    {
        public List<Vehiculo> Get()
        {
            return VehiculoData.VerVehiculos();
        }

        // GET api/<controller>/5
        public Vehiculo Get(int id)
        {
            return VehiculoData.ObtenerVehiculo(id);
        }

        public bool Post([FromBody] Vehiculo vehiculo)
        {
            return VehiculoData.RegistrarVehiculo(vehiculo);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return VehiculoData.EliminarVehiculo(id);
        }

        // Put api/<controller>/5
        public bool Put([FromBody] Vehiculo vehiculo)
        {
            return VehiculoData.ModificarVehiculo(vehiculo);
        }



        //Por el momento solo cree el metodo para poder ver los vehiculos, ya luego se puede ampliar la aplicacion
        //y crear los demas metodos


    }
}
